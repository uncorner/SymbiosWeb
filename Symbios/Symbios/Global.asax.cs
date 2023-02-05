using System;
using System.Web;
using log4net;
using Symbios.Core;

namespace Symbios {

    public class Global : HttpApplication, IErrorContext {
        private readonly ILog logger = LogManager.GetLogger(typeof(Global));

        protected void Application_Start(object sender, EventArgs e) {
            log4net.Config.XmlConfigurator.Configure();
            logger.Info("Start application");
        }

        protected void Application_Error(object sender, EventArgs e) {
            ErrorHandler.Handle(this);
        }

        protected void Application_End(object sender, EventArgs e) {
            logger.Info("Stop application");
        }

        protected void Session_Start(object sender, EventArgs e) {
        }

        protected void Application_BeginRequest(object sender, EventArgs e) {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {
        }

        protected void Session_End(object sender, EventArgs e) {
        }

        #region IErrorContext implements

        public Exception GetException() {
            return Server.GetLastError();
        }

        public void Redirect(string url) {
            Response.Redirect(url, true);
        }

        public void Transfer(string url) {
            Server.Transfer(url);
        }

        public void ClearError() {
            Server.ClearError();
        }

        public string GetRequestedUrl() {
            return Request.RawUrl;
        }

        #endregion

    }
}