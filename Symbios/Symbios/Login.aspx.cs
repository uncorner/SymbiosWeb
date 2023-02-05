using System;
using System.Web.Security;
using Ninject;
using Symbios.Core.Orm;

namespace Symbios {

    public partial class Login : System.Web.UI.Page {
        
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Request.IsAuthenticated) {
                    Response.Redirect(FormsAuthentication.DefaultUrl);
                }
                Title = "Symbios - Вход в систему";
            }
        }

        protected void loginButton_Click(object sender, EventArgs e) {
            Validate();
            if (!IsValid) {
                return;
            }
            if (AuthenticateUser(nameTextBox.Text, passwordTextBox.Text)) {
                FormsAuthentication.RedirectFromLoginPage(nameTextBox.Text, false);
            } else {
                nameTextBox.Text = string.Empty;
                passwordTextBox.Text = string.Empty;
                flash.AddError("Вы ввели неправильное имя пользователя и/или пароль. Пожалуйста, попробуйте еще раз.");
                Response.Redirect("~/Login.aspx");
            }
        }

        private static bool AuthenticateUser(string name, string password) {
            string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
            IKernel kernel = new StandardKernel(new StorageModule());
            var storage = kernel.Get<IDataStorage>();
            return storage.UserExists(name, hashedPassword);
        }

    }
}
