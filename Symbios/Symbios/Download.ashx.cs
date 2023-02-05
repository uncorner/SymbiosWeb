using System;
using System.Web;
using Ninject;
using Symbios.Core.Orm;

namespace Symbios {
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    public class Download : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            int id;
            try {
                id = Convert.ToInt32(context.Request.QueryString["id"]);
            } catch (Exception) {
                return;
            }
            IKernel kernel = new StandardKernel(new StorageModule());
            var storage = kernel.Get<IDataStorage>();
            var file = storage.FetchAppFileById(id);
            byte[] fileData = file.FileDataBytes;
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.FileName);
            context.Response.AddHeader("Content-Length", fileData.Length.ToString());
            context.Response.ContentType = "application/octet-stream";
            context.Response.BinaryWrite(fileData);
        }

        public bool IsReusable {
            get {
                return true;
            }
        }

    }
}
