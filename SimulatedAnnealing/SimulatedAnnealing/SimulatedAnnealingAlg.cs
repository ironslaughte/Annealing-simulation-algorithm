using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulatedAnnealing
{
    public class SimulatedAnnealingAlg
    {
        private Random random = new Random();
        private int _numCities;
        private double _initialTemperature, _endTemperature, _bestEnergy;
        private int[][] _dists;
        private List<int> _state;

        public Func<double,int,double> Decrease { private get; set; }


        public SimulatedAnnealingAlg(int numCities, double initialTemperature, double endTemperature)
        {
            _numCities = numCities;
            _initialTemperature = initialTemperature;
            _endTemperature = endTemperature;
            MakeGraphDistances();
        }

        public IEnumerable<(double,double)> Run()
        {
            InitFirstState();
            _bestEnergy = CalculateEnergy(_state);
            double temperature = _initialTemperature;
            int i = 1;
            while(temperature > _endTemperature)
            {
                List<int> stateCandidate = GenerateStateCandidate();
                double candidateEnergy = CalculateEnergy(stateCandidate);
                if(candidateEnergy < _bestEnergy)
                {
                    SetNewBestState(stateCandidate, candidateEnergy);
                }
                else
                {
                    double p = GetTransitionProbability(candidateEnergy - _bestEnergy, temperature);
                    if (MakeTransit(p))
                        SetNewBestState(stateCandidate, candidateEnergy);
                }
                yield return (_bestEnergy, temperature);
                temperature = DecreaseTemperature(i);
                i++;
            }
        }

        private void SetNewBestState(List<int> stateCandidate, double candidateEnergy)
        {
            _state = stateCandidate;
            _bestEnergy = candidateEnergy;
        }

        public double GetBestEnergy() => _bestEnergy;
        public int[][] GetGraph() => _dists;

        public List<int> GetBestState() => _state;
        private double DecreaseTemperature(int i) => Decrease(_initialTemperature ,i);

        private bool MakeTransit(double p) => random.Next() < p;

        private double GetTransitionProbability(double energy, double temperature) => Math.Exp(-energy / temperature);

        private List<int> GenerateStateCandidate()
        {
            int i = random.Next(_numCities);
            int j = random.Next(_numCities);
            List<int> stateCandidate = new List<int>(_state);
            int idxFirstCity = stateCandidate.FindIndex(x => x == i);
            int idxSecondCity = stateCandidate.FindIndex(x => x == j);
            if (idxFirstCity > idxSecondCity)
            {
                while(idxFirstCity > idxSecondCity)
                    stateCandidate.Swap(idxFirstCity--, idxSecondCity++);
            }
            else
            {
                while (idxFirstCity < idxSecondCity)
                    stateCandidate.Swap(idxFirstCity++, idxSecondCity--);
            }
                

            return stateCandidate;
        }

        private double CalculateEnergy(List<int> state)
        {
            double res = 0;
            for(int i = 0; i < _numCities-1; i++)
                res += Distance(state[i], state[i + 1]);

            res += Distance(state[0], state[_numCities - 1]);
            return res;
        }

        private void InitFirstState()
        {
            _state = new List<int>();

            for (int i = 0; i <= _numCities - 1; i++)
                _state.Add(i);

            for (int i = 0; i <= _numCities - 1; i++)
            {
                int r = random.Next(i, _numCities);
                int tmp = _state[r];
                _state[r] = _state[i];
                _state[i] = tmp;
            }

        }
        private void MakeGraphDistances()
        {
            _dists = new int[_numCities][];
            for (int i = 0; i <= _dists.Length - 1; i++)
                _dists[i] = new int[_numCities];
            for (int i = 0; i <= _numCities - 1; i++)
            {
                for (int j = i + 1; j <= _numCities - 1; j++)
                {
                    int d = random.Next(1, 9);
                    _dists[i][j] = d;
                    _dists[j][i] = d;
                }
            }
        }

        private double Distance(int cityX, int cityY) => _dists[cityX][cityY];
    }
}
