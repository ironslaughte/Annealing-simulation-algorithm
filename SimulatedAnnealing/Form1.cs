using K_means;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimulatedAnnealing
{
    public partial class Form1 : Form
    {
        SimulatedAnnealingAlg simulatedAnnealing;
        int _numCities;
        int[][] dists;
        double _initialTemperature, _endTemperature;
        public Form1()
        {
            InitializeComponent();
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
                foreach (var res in simulatedAnnealing.StartAlgSimulatedAnnealing())
                {
                    if (i % 30 == 0)
                        richTextBox1.Text += "Current temperature is " + res.Item2.ToString("F4") + ", value of energy is " + res.Item1 + "\n";
                    i++;
                }
                PrintBestState();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitializeDists(List<string[]> data)
        {
            dists = new int[data.Count][];
            for (int i = 0; i < data.Count; i++)
            {
                dists[i] = new int[data[i].Length];
                for (int j = 0; j < data[i].Length; j++)
                    dists[i][j] = int.Parse(data[i][j]);
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
            if(comboBox1.SelectedIndex==0)
                simulatedAnnealing = new SimulatedAnnealingAlg(dists.Length, _initialTemperature, _endTemperature, dists);
            else
                simulatedAnnealing = new SimulatedAnnealingAlg(_numCities, _initialTemperature, _endTemperature);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                var data = FileReader.Read("Graph.txt");
                InitializeDists(data);
                textBoxNumCities.Enabled = false;
            }
            else
                textBoxNumCities.Enabled = true;
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
