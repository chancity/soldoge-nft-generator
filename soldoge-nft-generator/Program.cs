using System.Collections.Generic;
using System.IO;

namespace soldoge_nft_generator
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const string partDirectory = "PNG/";
            const int solDogesToCreate = 20;
            
            Directory.CreateDirectory("assets");
            
            var partMap = PartMap.FromFileSystem(partDirectory);
            var partPicker = new PartPicker(partMap);
            var createdSolDoges = new HashSet<SolDoge>();
          
            var i = 0;

            while (i < solDogesToCreate)
            {
                if (createdSolDoges.Add(new SolDoge() {
                    partPicker.Pick(SolDogePartType.Background),
                    partPicker.Pick(SolDogePartType.Base),
                    partPicker.Pick(SolDogePartType.Backpack),
                    partPicker.Pick(SolDogePartType.Clothes,SolDogePartType.Collar),
                    partPicker.Pick(SolDogePartType.Eyes, SolDogePartType.Eyewear),
                    partPicker.Pick(SolDogePartType.Mouth),
                    partPicker.Pick(SolDogePartType.Headwear, SolDogePartType.Hair),
                })) {
                    i++;
                }
            }
            
            var namePostFix = 0;
            foreach (var solDoge in createdSolDoges)
            {
                solDoge.SaveAsImage($"assets/SolDoge #{namePostFix}.bmp");
                namePostFix++;
            }
        }
    }
}
