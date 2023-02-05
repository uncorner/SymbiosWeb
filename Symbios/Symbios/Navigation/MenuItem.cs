namespace Symbios.Navigation {

    public class MenuItem {
        public string Label { get; private set; }

        public string Url { get; private set; }

        public MenuItem(string name, string url) {
            Label = name;
            Url = url;
        }

    }

}