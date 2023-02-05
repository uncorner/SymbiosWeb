using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.UI;

namespace Symbios.Controls {

    public partial class AppPreviewList : UserControl {
        private int? descrMaxLength;
        private bool isEmpty = true;
        
        public IList<Core.Models.App> AppCollection {
            set {
                appList.DataSource = value;
                if (value != null && value.Count > 0) {
                    isEmpty = false;
                    DataBind();
                }
                else {
                    isEmpty = true;
                }
            }
        }

        public string NoDataMessage {
            set {
                noDataLabel.Text = value;
            }
        }

        public string Caption {
            set {
                captionLabel.Text = value;
            }
        }

        public AppPreviewList() {
            PreRender += AppPreviewList_PreRender;
        }

        protected void Page_Load(object sender, EventArgs e) {
            captionLabel.Visible = false;
            noDataLabel.Visible = false;
        }

        protected string MakeShortDescription(string source) {
            var description = HttpUtility.HtmlEncode(source);
            if (!descrMaxLength.HasValue) {
                descrMaxLength = Convert.ToInt32(ConfigurationManager.AppSettings["shortDescriptionLength"]);
            }
            if (description.Length > descrMaxLength.Value) {
                return description.Substring(0, descrMaxLength.Value) + "...";
            }
            return description;
        }

        void AppPreviewList_PreRender(object sender, EventArgs e) {
            if (IsPostBack) {
                return;
            }
            if (isEmpty) {
                if (!string.IsNullOrEmpty(noDataLabel.Text)) {
                    noDataLabel.Visible = true;
                }
            } else {
                if (!string.IsNullOrEmpty(captionLabel.Text)) {
                    captionLabel.Visible = true;
                }
            }
        }

    }
}