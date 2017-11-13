using System;

namespace Festispec.ViewModels.Routes
{
    public static class Routes
    {
        public static Route Home = new Route {Key = "Home", PageType = new Uri("../MainWindow.xaml", UriKind.Relative)};

        #region Template

        public static Route TemplateList = new Route
        {
            Key = "TemplateList",
            PageType = new Uri("../Views/Template/TemplateList.xaml", UriKind.Relative)
        };

        public static Route TemplateAdd = new Route
        {
            Key = "TemplateAdd",
            PageType = new Uri("../Views/Template/TemplateAdd.xaml", UriKind.Relative)
        };

        public static Route TemplateUpdate = new Route
        {
            Key = "TemplateUpdate",
            PageType = new Uri("../Views/Template/TemplateAdd.xaml", UriKind.Relative)
        };

        public static Route AddQuestion = new Route
        {
            Key = "AddQuestion",
            PageType = new Uri("../Views/Template/AddQuestion.xaml", UriKind.Relative)
        };

        #endregion
    }
}