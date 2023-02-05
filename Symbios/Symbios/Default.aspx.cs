using System;
using System.Configuration;
using Ninject;
using Symbios.Core.Orm;

namespace Symbios
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Title = "Symbios";
                IKernel kernel = new StandardKernel(new StorageModule());
                var storage = kernel.Get<IDataStorage>();
                int maxCount = Convert.ToInt32(ConfigurationManager.AppSettings["recentCount"]);
                appList.AppCollection = storage.FetchRecentApps(maxCount);
            }
        }

    }
}
