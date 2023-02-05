using System.Web;
using System.Web.Security;

namespace Symbios {
    public class Logout : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            if (context.Request.IsAuthenticated) {
                FormsAuthentication.SignOut();
                context.Response.Redirect("~/Login.aspx");
            }
        }

        public bool IsReusable {
            get {
                return true;
            }
        }

    }
}
