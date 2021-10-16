using System;
using System.Collections.Generic;
using System.Linq;

namespace soldoge_nft_generator
{
    public class PartPicker
    {
        private static Random _random = new Random();

        private Dictionary<SolDogePartType, HashSet<SolDogePart>> _partMap;

        public PartPicker(Dictionary<SolDogePartType, HashSet<SolDogePart>> partMap)
        {
            _partMap = partMap;
        }

        public SolDogePart Pick(params SolDogePartType[] partTypes)
        {
            var mergedPartTypes = new HashSet<SolDogePart>();
            foreach (var solDogePartType in partTypes)
            {
                mergedPartTypes.UnionWith(_partMap[solDogePartType]);
            }

            var weights = mergedPartTypes.Select(background => background.Rarity);
            return _random.Choice(mergedPartTypes, weights);
        }
    }
}