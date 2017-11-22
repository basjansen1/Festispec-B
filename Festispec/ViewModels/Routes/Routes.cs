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

        #region Employee

        public static Route EmployeeList = new Route
        {
            Key = "EmployeeList",
            PageType = new Uri("../Views/Employee/EmployeeList.xaml", UriKind.Relative)
        };

        public static Route EmployeeAddOrUpdate = new Route
        {
            Key = "EmployeeAddOrUpdate",
            PageType = new Uri("../Views/Employee/EmployeeAddOrUpdate.xaml", UriKind.Relative)
        };

        public static Route InspectorList = new Route
        {
            Key = "InspectorList",
            PageType = new Uri("../Views/Inspector/InspectorList.xaml", UriKind.Relative)
        };

        public static Route InspectorAddOrUpdate = new Route
        {
            Key = "InspectorAddOrUpdate",
            PageType = new Uri("../Views/Inspector/InspectorAddOrUpdate.xaml", UriKind.Relative)
        };

        #endregion
    }
}