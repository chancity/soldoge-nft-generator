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
            const int width = 1440;
            const int height = 1440;
            Bitmap bitmap = new(width, height);
            using Graphics g = Graphics.FromImage(bitmap);
            IList enumerable = images as IList ?? images.ToList();
            foreach (Image image in enumerable) 
            {
                g.DrawImage(image, 0, 0);
            }
            return bitmap;
        }
        
        public bool SaveAsImage(string filePath)
        {
            if (Count <= 0) return false;
            List<Image> images = this.Select(solDogePart => Image.FromFile(solDogePart.AssetPath)).ToList();
            Bitmap mergedBitmap = Merge(images);
            mergedBitmap.Save(filePath);
            return true;
        }
        
        
    }
}