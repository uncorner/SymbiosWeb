using System;
using Ninject;
using Symbios.Core;
using Symbios.Core.Orm;

namespace Symbios
{
    public partial class Category : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                string tag = Request.QueryString["tag"];
                if (string.IsNullOrEmpty(tag)) {
                    throw new ParameterNotFoundException("tag");
                }
                IKernel kernel = new StandardKernel(new StorageModule());
                var storage = kernel.Get<IDataStorage>();
                var category = storage.FetchCategoryByTag(tag);
                Title = category != null ? "Symbios - " + category.Name : "Symbios";
                appList.AppCollection = storage.FetchAppsByCategoryTag(tag);
            }
        }
      
    }
}
