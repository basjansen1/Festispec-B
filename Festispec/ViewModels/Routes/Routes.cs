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

        public static Route TemplateAddOrUpdate = new Route
        {
            Key = "TemplateAddOrUpdate",
            PageType = new Uri("../Views/Template/TemplateAddOrUpdate.xaml", UriKind.Relative)
        };

        public static Route TemplateQuestionAddOrUpdate = new Route
        {
            Key = "TemplateQuestionAddOrUpdate",
            PageType = new Uri("../Views/Template/TemplateQuestionAddOrUpdate.xaml", UriKind.Relative)
        };

        public static Route TemplateQuestionAdd = new Route
        {
            Key = "TemplateQuestionAdd",
            PageType = new Uri(" ../Views/Template/TemplateQuestionAdd.xaml", UriKind.Relative)
        };

        #endregion
    }
}