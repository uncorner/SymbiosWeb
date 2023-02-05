using System.Drawing;
using System.IO;

namespace Symbios.Core {

    public class ImageService {

        public static byte[] ScaleRawImage(byte[] source, int maxSize) {
            Image sourceImage = new Bitmap(new MemoryStream(source));
            var resultImage = ScaleImage(sourceImage, maxSize);
            var resStream = new MemoryStream();
            resultImage.Save(resStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return resStream.GetBuffer();
        }

        private static Image ScaleImage(Image source, int maxSize) {
            double k;
            int destWidth, destHeight;
            if (source.Width > source.Height) {
                destWidth = maxSize;
                k = (double) maxSize / source.Width;
                destHeight = (int)(source.Height * k);
            } else {
                destHeight = maxSize;
                k = (double)maxSize / source.Height;
                destWidth = (int)(source.Width * k);
            }
            Image dest = new Bitmap(destWidth, destHeight);            
            using (Graphics gr = Graphics.FromImage(dest)) {
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gr.DrawImage(source, 0, 0, destWidth, destHeight);
                return dest;
            }
        }
        
    }

}
