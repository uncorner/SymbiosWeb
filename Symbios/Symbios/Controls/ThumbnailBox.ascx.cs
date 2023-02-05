using System;
using System.Web;

namespace Symbios.Controls {

    public partial class ThumbnailBox : System.Web.UI.UserControl {

        public int? ImageId {
            set {
                if (value.HasValue) {
                    image.ImageUrl = "~/ShowThumbnail.ashx?id="
                                     + HttpUtility.UrlEncode(value.Value.ToString());
                    Visible = true;
                } else {
                    image.ImageUrl = null;
                    Visible = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
        }

    }
}