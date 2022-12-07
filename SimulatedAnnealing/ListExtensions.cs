using System.Collections.Generic;

namespace SimulatedAnnealing
{
    public static class ListExtensions
    {
        public static void Swap(this List<int> list, int i , int j) 
        {
            int tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }
    }
}
