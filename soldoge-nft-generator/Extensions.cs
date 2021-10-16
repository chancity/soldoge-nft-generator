using System;
using System.Collections.Generic;

namespace soldoge_nft_generator
{
    internal static class Extensions
    {
        public static T Choice<T>(this Random rnd, IEnumerable<T> choices, IEnumerable<int> weights) where T : class
        {
            var cumulativeWeight = new List<int>();
            var last = 0;
            foreach (var current in weights)
            {
                last += current;
                cumulativeWeight.Add(last);
            }
            var choice = rnd.Next(last);
            var i = 0;
            foreach (var cur in choices)
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
