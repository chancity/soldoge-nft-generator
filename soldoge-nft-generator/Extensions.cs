using System;
using System.Collections.Generic;

namespace soldoge_nft_generator
{
    internal static class Extensions
    {
        public static T Choice<T>(this Random rnd, IEnumerable<T> choices, IEnumerable<int> weights) where T : class
        {
            List<int> cumulativeWeight = new();
            int last = 0;
            foreach (int current in weights)
            {
                last += current;
                cumulativeWeight.Add(last);
            }
            int choice = rnd.Next(last);
            int i = 0;
            foreach (T cur in choices)
            {
                if (choice < cumulativeWeight[i])
                {
                    return cur;
                }
                i++;
            }
            return null;
        }
    }
}
