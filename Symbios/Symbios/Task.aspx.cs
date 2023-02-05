using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Ninject;
using Symbios.Core.Models;
using Symbios.Core.Orm;

namespace Symbios {

    public partial class Task : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            string currentTime = DateTime.Now.ToLongTimeString();
            pageTimeLabel.Text = currentTime;
            panelTimeLabel.Text = currentTime;
            if (!IsPostBack) {
                Title = "Task Page";
                var storage = GetStorage();
                listView.DataSource = storage.FetchAllPlanets();
                DataBind();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e) {
            var items = listView.Items;
            IList<Planet> planets = new List<Planet>();
            foreach (var item in items) {
                Label nameLabel = (Label)item.FindControl("nameLabel");
                TextBox descrTextBox = (TextBox)item.FindControl("descrTextBox");
                if (descrTextBox != null && nameLabel != null) {
                    var planet = new Planet {
                        Name = nameLabel.Text,
                        Description = descrTextBox.Text
                    };
                    planets.Add(planet);
                }
            }
            if (planets.Count > 0) {
                IDataStorage storage = GetStorage();
                storage.UpdatePlanets(planets);
            }
        }

        private static IDataStorage GetStorage() {
            IKernel kernel = new StandardKernel(new StorageModule());
            return kernel.Get<IDataStorage>();
        }
        
    }
}
