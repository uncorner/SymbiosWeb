using System;
using System.Web;
using Ninject;
using Symbios.Core.Orm;

namespace Symbios {
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    public class ShowThumbnail : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            int id;
            try {
                id = Convert.ToInt32(context.Request.QueryString["id"]);
            }
            catch(Exception) {
                return;
            }
            IKernel kernel = new StandardKernel(new StorageModule());
            var storage = kernel.Get<IDataStorage>();
            var screenshot = storage.FetchScreenshotById(id);
            context.Response.ContentType = "image/jpg";
            context.Response.BinaryWrite(screenshot.ThumbDataBytes);
        }

        public bool IsReusable {
            get {
                return true;
            }
        }

    }
}
