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
            return input.Length switch
            {
                0 => input,
                1 => char.ToUpper(input[0]).ToString(),
                _ => char.ToUpper(input[0]) + input[1..]
            };
        }
        
        public static Dictionary<SolDogePartType, HashSet<SolDogePart>> FromFileSystem(string partDirectory)
        {

            Dictionary<SolDogePartType, HashSet<SolDogePart>> solDogePartMap = new();
            string[] partTypes = Enum.GetNames<SolDogePartType>();

            foreach (string solDogePartDirectory in Directory.EnumerateDirectories(partDirectory))
            {
                string normalizedDirectoryName = UpperCaseFirstLetter(solDogePartDirectory.Replace(partDirectory, ""));
               
                if (!partTypes.Contains(normalizedDirectoryName)) continue;
                
                SolDogePartType solDogePartType = Enum.Parse<SolDogePartType>(normalizedDirectoryName);
                HashSet<SolDogePart> solDogeParts = new();
                
                solDogePartMap.Add(solDogePartType, solDogeParts);

                foreach (string solDogePartAssetPath in Directory.EnumerateFiles(solDogePartDirectory))
                {
                    string name = new FileInfo(solDogePartAssetPath).Name.Split(".")[0];
                    SolDogePart part = new(solDogePartAssetPath, solDogePartType, 1, name, name);

                    solDogeParts.Add(part);
                }
            }

            return solDogePartMap;
            
        }
    }
}