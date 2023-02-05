using System;
using System.Web.UI.WebControls;
using Ninject;
using Symbios.Core;
using Symbios.Core.Models;
using Symbios.Core.Orm;

namespace Symbios
{
    public partial class Upload : System.Web.UI.Page {
        private readonly IDataStorage storage;

        public Upload() {
            IKernel kernel = new StandardKernel(new StorageModule());
            storage = kernel.Get<IDataStorage>();
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Title = "Symbios - Добавление нового приложения";
                var cats = storage.FetchAllCategories();
                foreach (var category in cats) {
                    categoryList.Items.Add(new ListItem(category.Name, category.Tag));
                }
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e) {
            if (!fileUpload.HasFile) {
                return;
            }
            var app = new App {
                CategoryTag = categoryList.SelectedValue,
                Title = titleTextBox.Text,
                Description = descriptionTextBox.Text,
                Website = websiteTextBox.Text,
                Created = DateTime.Now
            };
            var appFile = new AppFile();
            appFile.FileName = fileUpload.FileName;
            appFile.FileDataBytes = fileUpload.FileBytes;
            app.AppFile = appFile;
            if (screenshotUpload.HasFile) {
                var screenshot = new Screenshot();
                screenshot.ThumbDataBytes = ImageService.ScaleRawImage(screenshotUpload.FileBytes, 100);
                screenshot.ImageDataBytes = ImageService.ScaleRawImage(screenshotUpload.FileBytes, 300);
                app.Screenshot = screenshot;
            }
            storage.SaveAppWithItems(app);
            // TODO: вывод сообщения об успешном добавлении
            Response.Redirect("~/");
        }

    }
}
