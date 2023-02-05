using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Symbios.Navigation;

namespace Symbios.Controls {

    public partial class MainMenu : System.Web.UI.UserControl {
        private readonly IList<MenuItem> items = new List<MenuItem>();

        protected void Page_Load(object sender, EventArgs e) {
        }

        public MainMenu AddItem(MenuItem item) {
            items.Add(item);
            return this;
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer) {
            base.Render(writer);
            if (items.Count == 0) {
                return;
            }
            var html = new StringBuilder();
            html.Append(@"<ul id=""main-menu-list"">");
            foreach (var item in items) {
                html.Append("<li>");
                html.Append(string.Format(@"<a href=""{0}"">{1}</a>",
                     VirtualPathUtility.ToAbsolute(item.Url), item.Label));
                html.Append("</li>");
            }
            html.Append("</ul>");
            writer.Write(html);
        }

    }
}