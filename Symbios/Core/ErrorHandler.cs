using System;
using System.Web;
using log4net;

namespace Symbios.Core {

    public static class ErrorHandler {
        public const string NOT_FOUND_URL = "~/NotFound.htm";
        public const string TROUBLE_URL = "~/Trouble.htm";
        public const string ROOT_URL = "~/";
        private readonly static ILog LOGGER = LogManager.GetLogger(typeof(ErrorHandler));
        
        public static void Handle(IErrorContext context) {
            if (context == null) {
                throw new ArgumentNullException("context");
            }
            Exception ex = context.GetException();
            if (ex == null) {
                LOGGER.Warn("Exception is null. Do nothing.");
                return;
            }
            context.ClearError();
            var httpEx = ex as HttpException;
            if (httpEx != null) {
                if (httpEx.GetHttpCode() == 404) {
                    LOGGER.Warn("Resource is not found: " + context.GetRequestedUrl());
                    LOGGER.Info("Transfer to " + NOT_FOUND_URL);
                    context.Transfer(NOT_FOUND_URL);
                    return;
                }
                var innerEx = httpEx.InnerException;
                if (innerEx != null &&
                    innerEx is ParameterNotFoundException) {
                    LOGGER.Error(httpEx.ToString());
                    LOGGER.Info("Redirect to " + ROOT_URL);
                    context.Redirect(ROOT_URL);
                    return;
                }
            }
            // NOTE: unhandled exception
            LOGGER.Fatal(ex.ToString());
            LOGGER.Info("Redirect to " + TROUBLE_URL);
            context.Redirect(TROUBLE_URL);
        }
        
    }

}