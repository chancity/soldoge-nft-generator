using System.Collections.Generic;
using System.IO;

namespace soldoge_nft_generator
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const string partDirectory = "PNG/";
            const string saveDirectory = "assets/";
            const string collectionName = "SolDoge";
            const int solDogesToCreate = 20;
            
            Directory.CreateDirectory(saveDirectory);

            Dictionary<SolDogePartType, HashSet<SolDogePart>> partMap = PartMap.FromFileSystem(partDirectory);
            PartPicker partPicker = new(partMap);
            
            var i = 0;
            var createdSolDoges = new HashSet<SolDoge>();
            while (i < solDogesToCreate)
            {
                if (createdSolDoges.Add(new SolDoge {
                    partPicker.Pick(SolDogePartType.Background),
                    partPicker.Pick(SolDogePartType.Base),
                    partPicker.Pick(SolDogePartType.Backpack),
                    partPicker.Pick(SolDogePartType.Clothes, SolDogePartType.Collar),
                    partPicker.Pick(SolDogePartType.Eyes, SolDogePartType.Eyewear),
                    partPicker.Pick(SolDogePartType.Mouth),
                    partPicker.Pick(SolDogePartType.Headwear, SolDogePartType.Hair),
                })) {
                    i++;
                }
            }
            
            var namePostFix = 0;
            foreach (SolDoge solDoge in createdSolDoges)
            {
                solDoge.SaveAsImage($"{saveDirectory}/{collectionName} #{namePostFix}.bmp");
                namePostFix++;
            }
        }
    }
}
