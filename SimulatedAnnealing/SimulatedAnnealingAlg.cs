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


        public SimulatedAnnealingAlg(int numCities, double initialTemperature, double endTemperature, int[][] dists = null)
        {
            _numCities = numCities;
            _initialTemperature = initialTemperature;
            _endTemperature = endTemperature;
            if (dists != null)
                _dists = dists;
            else
                _dists = GraphMaker.MakeGraphDistances(numCities);
            InitRandomFirstState();
        }

        public IEnumerable<(double,double)> StartAlgSimulatedAnnealing()
        {           
            _bestEnergy = CalculateEnergy(_state);
            double temperature = _initialTemperature;
            int i = 1;
            while(temperature > _endTemperature)
            {
                List<int> stateCandidate = GenerateStateCandidate();
                double candidateEnergy = CalculateEnergy(stateCandidate);
                MakeNewState(temperature, stateCandidate, candidateEnergy);
                yield return (_bestEnergy, temperature);
                temperature = _initialTemperature / i;
                i++;
            }
        }

        private void MakeNewState(double temperature, List<int> stateCandidate, double candidateEnergy)
        {
            if (candidateEnergy < _bestEnergy)
            {
                _state = stateCandidate;
                _bestEnergy = candidateEnergy;
            }
            else
            {
                double p = Math.Exp(-(candidateEnergy - _bestEnergy) / temperature);
                if (random.NextDouble() < p)
                {
                    _state = stateCandidate;
                    _bestEnergy = candidateEnergy;
                }
                    
            }
        }

        public double GetBestEnergy() => _bestEnergy;
        public int[][] GetGraph() => _dists;

        public List<int> GetBestState() => _state;

        private List<int> GenerateStateCandidate()
        {
            int i = random.Next(_numCities);
            int j = random.Next(_numCities);
            List<int> stateCandidate = new List<int>(_state);
            int idxFirstCity = stateCandidate.FindIndex(x => x == i);
            int idxSecondCity = stateCandidate.FindIndex(x => x == j);
            if (idxFirstCity > idxSecondCity)
            {
                while (idxFirstCity > idxSecondCity)
                {
                    stateCandidate.Swap(idxFirstCity--, idxSecondCity++);
                    idxFirstCity -= 1;
                    idxSecondCity += 1;
                }

            }
            else
            {
                while (idxFirstCity < idxSecondCity)
                {
                    stateCandidate.Swap(idxFirstCity, idxSecondCity);
                    idxFirstCity += 1;
                    idxSecondCity -= 1;
                }
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

        private void InitRandomFirstState()
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
        private double Distance(int cityX, int cityY) => _dists[cityX][cityY];
    }
}
