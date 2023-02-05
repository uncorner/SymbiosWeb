namespace Symbios.Core.Models {

    public partial class AppFile {

        public byte[] FileDataBytes {
            set {
                FileData = value;
            }
            get {
                return FileData.ToArray();
            }
        }

    }
}