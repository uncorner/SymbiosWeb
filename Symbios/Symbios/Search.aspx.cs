using System;
using log4net;
using Ninject;
using Symbios.Core;
using Symbios.Core.Orm;

namespace Symbios {

    public partial class Search : System.Web.UI.Page {
        private readonly ILog logger = LogManager.GetLogger(typeof(Search));

        protected void Page_Load(object sender, EventArgs e) {
            string pattern = Request.QueryString["pattern"];
            if (pattern != null) {
                pattern = pattern.Trim();
            }
            if (string.IsNullOrEmpty(pattern)) {
                throw new ParameterNotFoundException("pattern");
            }
            Title = "Symbios - Результаты поиска";
            logger.Info(string.Format("Search the apps by pattern is '{0}'", pattern));
            IKernel kernel = new StandardKernel(new StorageModule());
            var storage = kernel.Get<IDataStorage>();
            var found = storage.FetchAppsBySearchPattern(pattern);
            if (found != null && found.Count > 0) {
                appList.Caption = "Найдено приложений: " + found.Count;
            }
            appList.AppCollection = found;
        }

    }
}
