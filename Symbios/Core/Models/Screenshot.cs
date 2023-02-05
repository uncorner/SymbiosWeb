namespace Symbios.Core.Models {

    public partial class Screenshot {

        public byte[] ThumbDataBytes {
            get {
                return ThumbData.ToArray();
            }
            set {
                ThumbData = value;
            }
        }

        public byte[] ImageDataBytes {
            get {
                return ImageData.ToArray();
            }
            set {
                ImageData = value;
            }
        }

    }

}
