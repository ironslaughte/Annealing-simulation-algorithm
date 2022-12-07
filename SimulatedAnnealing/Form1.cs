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
                richTextBox1.Text = "";
                InitSimulatedAnnealing();
                int i = 0;
                foreach (var res in simulatedAnnealing.Run())
                {
                    if (i % 30 == 0)
                        richTextBox1.Text += "Current temperature is " + res.Item2 + ", value of energy is " + res.Item1 + "\n";
                    i++;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            if(_numCities <=0 || _initialTemperature <= 0 || _endTemperature <= 0)
                throw new ArgumentException("Параметры введены некорректно");
        }
    }
}
