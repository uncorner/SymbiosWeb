using System;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using Ninject;
using Symbios.Controls;
using Symbios.Core.Orm;
using Symbios.Navigation.Items;

namespace Symbios
{
    public partial class Template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                IKernel kernel = new StandardKernel(new StorageModule());
                var storage = kernel.Get<IDataStorage>();
                var cats = storage.FetchAllCategories();
                foreach (var category in cats) {
                    var item = new MenuItem(HttpUtility.HtmlEncode(category.Name)) {
                        NavigateUrl = "~/Category.aspx?tag=" + HttpUtility.UrlEncode(category.Tag)
                    };
                    string resolvedUrl = ResolveUrl(item.NavigateUrl);
                    if (resolvedUrl == Request.RawUrl) {
                        item.Selectable = false;
                    }
                    menu.Items.Add(item);
                }
                // init main menu
                var mainMenu = new MainMenu()
                    .AddItem(new UploadAppItem())
                    .AddItem(new LogoutItem());
                mainMenuPlaceHolder.Controls.Add(mainMenu);
            }
        }

        protected void searchButton_Click(object sender, EventArgs e) {
            var url = "~/Search.aspx?pattern="
                + HttpUtility.UrlEncode(searchTextBox.Text);
            Response.Redirect(url);
        }

        protected void logoutLinkButton_Click(object sender, EventArgs e) {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }

    }

}
