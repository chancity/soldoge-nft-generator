using System.Collections.Generic;
using System.IO;

namespace soldoge_nft_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("assets");
            var partDirectory = "PNG/";
            var partMap = PartMap.FromFileSystem(partDirectory);
            var partPicker = new PartPicker(partMap);

            var createSolDoges = new HashSet<SolDoge>();
            var solDogesToCreate = 20;
            var i = 0;

            while (i < solDogesToCreate)
            {
                if (createSolDoges.Add(new SolDoge() {
                    partPicker.Pick(SolDogePartType.Background),
                    partPicker.Pick(SolDogePartType.Base),
                    partPicker.Pick(SolDogePartType.Backpack),
                    partPicker.Pick(SolDogePartType.Clothes),
                    partPicker.Pick(SolDogePartType.Collar),
                    partPicker.Pick(SolDogePartType.Eyes, SolDogePartType.Eyewear),
                    partPicker.Pick(SolDogePartType.Headwear, SolDogePartType.Hair),
                    partPicker.Pick(SolDogePartType.Mouth),
                })) {
                    i++;
                }
            }
            
            var namePostFix = 0;
            foreach (var solDoge in createSolDoges)
            {
                solDoge.SaveAsImage($"assets/SolDoge #{namePostFix}.bmp");
                namePostFix++;
            }
        }
    }
}
