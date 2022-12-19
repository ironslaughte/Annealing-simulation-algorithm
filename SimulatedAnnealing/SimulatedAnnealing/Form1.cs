using System;
using System.Windows.Forms;

namespace SimulatedAnnealing
{
    public partial class Form1 : Form
    {
        SimulatedAnnealingAlg simulatedAnnealing;
        int _numCities;
        double _initialTemperature, _endTemperature;

        Func<double, int, double> LoweringTemp;
        public Form1()
        {
            InitializeComponent();
            LoweringTemp = LoweringTemperature.Default;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                ParseParams();
                InitSimulatedAnnealing();
                richTextBox1.Text = "";
                int[][] graph = simulatedAnnealing.GetGraph();
                PrintGraph(graph);
                int i = 0;
                foreach (var res in simulatedAnnealing.Run())
                {
                    if (i % 30 == 0)
                        richTextBox1.Text += "Current temperature is " + res.Item2 + ", value of energy is " + res.Item1 + "\n";
                    i++;
                }
                PrintBestState();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrintBestState()
        {
            var bestState = simulatedAnnealing.GetBestState();
            richTextBox1.Text += "Actual best state: ";
            foreach (var city in bestState)
                richTextBox1.Text += $"{city+1}; ";
            richTextBox1.Text += $"{bestState[0] + 1}; ";
        }

        private void PrintGraph(int[][] graph)
        {
            labelGraph.Text = "   ";
            for (int i = 0; i < graph.Length; i++)
                labelGraph.Text += $"{i + 1} ";
            labelGraph.Text += "\n";
            for (int i = 0; i < graph.Length; i++)
            {
                labelGraph.Text += $"{i + 1}: ";
                for (int j = 0; j < graph[i].Length; j++)
                    labelGraph.Text += $"{graph[i][j]} ";
                labelGraph.Text += "\n";
            }
        }

        private void InitSimulatedAnnealing()
        {
            simulatedAnnealing = new SimulatedAnnealingAlg(_numCities, _initialTemperature, _endTemperature);
            simulatedAnnealing.Decrease = LoweringTemp;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxLoweringTemp = comboBox1.SelectedIndex;
            if (idxLoweringTemp == 0)
                LoweringTemp = LoweringTemperature.Default;
            else
                LoweringTemp = LoweringTemperature.LinearReduction;           
        }

        private void ParseParams()
        {
            _numCities = Int32.Parse(textBoxNumCities.Text);
            _initialTemperature = Double.Parse(textBoxInitialTemp.Text); 
            _endTemperature = Double.Parse(textBoxEndTemp.Text);

            if(_numCities <=0 || _initialTemperature <= 0 || _endTemperature <= 0 || _numCities > 10)
                throw new ArgumentException("Параметры введены некорректно");
        }
    }
}
