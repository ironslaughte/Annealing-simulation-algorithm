using System;


namespace SimulatedAnnealing
{
    static class LoweringTemperature
    {
        public static double LinearReduction(double temperature, int numIteration) => temperature / (double)numIteration;

        public static double Default(double temperature, int numIteration) => temperature * 0.1 / numIteration;

        //public static double LogarithmicReduction(double temperature, int numIteration) => temperature / Math.Log(1+numIteration);
    }
}
