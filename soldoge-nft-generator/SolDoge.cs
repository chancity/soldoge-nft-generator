using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace soldoge_nft_generator
{
    public class SolDoge : HashSet<SolDogePart>
    {
        private static Bitmap Merge(IEnumerable<Image> images)
        {
            var enumerable = images as IList ?? images.ToList();
            var width = 1440;
            var height = 1440;
        
            // merge images
            var bitmap = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bitmap))
            {
                foreach (Image image in enumerable) 
                {
                    g.DrawImage(image, 0, 0);
                }
            }
            return bitmap;
        }
        
        public bool SaveAsImage(string filePath)
        {
            if (Count > 0)
            {
                var images = new List<Image>();
                foreach (var solDogePart in this)
                {
                    images.Add(Image.FromFile(solDogePart.AssetPath));
                }

                var mergedBitmap = Merge(images);
                mergedBitmap.Save(filePath);

                return true;
            }

            return false;
        }
        
        
    }
}