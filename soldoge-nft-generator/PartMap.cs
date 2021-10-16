using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace soldoge_nft_generator
{
    public static class PartMap
    {
        private static string UpperCaseFirstLetter(string input)
        {
            if (input.Length == 0)
                return input;

            if (input.Length == 1)
                return char.ToUpper(input[0]).ToString();

            return char.ToUpper(input[0]) + input.Substring(1);
        }
        
        public static Dictionary<SolDogePartType, HashSet<SolDogePart>> FromFileSystem(string partDirectory)
        {

            var solDogePartMap = new Dictionary<SolDogePartType, HashSet<SolDogePart>>();
            var partTypes = Enum.GetNames<SolDogePartType>();

            foreach (var solDogePartDirectory in Directory.EnumerateDirectories(partDirectory))
            {
                var normalizedDirectoryName = UpperCaseFirstLetter(solDogePartDirectory.Replace(partDirectory, ""));
               
                if (!partTypes.Contains(normalizedDirectoryName)) continue;
                
                var solDogePartType = Enum.Parse<SolDogePartType>(normalizedDirectoryName);
                var solDogeParts = new HashSet<SolDogePart>();
                
                solDogePartMap.Add(solDogePartType, solDogeParts);

                foreach (var solDogePartAssetPath in Directory.EnumerateFiles(solDogePartDirectory))
                {
                    var name = new FileInfo(solDogePartAssetPath).Name.Split(".")[0];
                    var part = new SolDogePart(solDogePartAssetPath, solDogePartType, 1, name, name);

                    solDogeParts.Add(part);
                }
            }

            return solDogePartMap;
            
        }
    }
}