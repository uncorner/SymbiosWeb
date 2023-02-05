using System;
using System.Collections.Generic;
using System.Text;

namespace Symbios.Controls {

    public partial class FlashMessage : System.Web.UI.UserControl {
        private const string ERROR_MESSAGES = "flash_error_messages";
        private const string INFO_MESSAGES = "flash_info_messages";

        protected void Page_Load(object sender, EventArgs e) {
        }

        public void AddError(string message) {
           AddMessage(ERROR_MESSAGES, message);
        }

        public void AddInfo(string message) {
            AddMessage(INFO_MESSAGES, message);
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer) {
            base.Render(writer);
            if (IsPostBack) {
                return;
            }
            var html = new StringBuilder();
            var errorMessages = Session[ERROR_MESSAGES] as IList<string>;
            if (errorMessages != null) {
                html.Append(RenderList(errorMessages, "error"));
                Session[ERROR_MESSAGES] = null;
            }
            var infoMessages = Session[INFO_MESSAGES] as IList<string>;
            if (infoMessages != null) {
                html.Append(RenderList(infoMessages, "info"));
                Session[INFO_MESSAGES] = null;
            }
            if (html.Length > 0) {
                writer.Write(@"<div id=""flash-message"">"
                    + html + "</div>");
            } 
        }

        private void AddMessage(string key, string message) {
            var messages = Session[key] as IList<string>
                ?? new List<string>();
            messages.Add(message);
            Session[key] = messages;
        }

        private string RenderList(IList<string> lines, string cssClass) {
            var html = new StringBuilder();
            html.AppendFormat(@"<ul class=""{0}"">", cssClass);
            foreach (var line in lines) {
                html.AppendFormat("<li>{0}</li>", line);
            }
            html.Append("</ul>");
            return html.ToString();
        }

    }
}