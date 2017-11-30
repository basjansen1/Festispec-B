using System;

namespace Festispec.Routes
{
    public static class Routes
    {
        public static Route Home = new Route {Key = "Home", PageType = new Uri("../MainWindow.xaml", UriKind.Relative)};

        #region Template

        public static Route TemplateList = new Route
        {
            Key = "TemplateList",
            PageType = new Uri("../Views/Template/TemplateList.xaml", UriKind.Relative),
            Roles = new []{"Manager", "Medewerker"}
        };

        public static Route TemplateAddOrUpdate = new Route
        {
            Key = "TemplateAddOrUpdate",
            PageType = new Uri("../Views/Template/TemplateAddOrUpdate.xaml", UriKind.Relative),
            Roles = new[] { "Manager", "Medewerker" }
        };

        public static Route TemplateQuestionAddOrUpdate = new Route
        {
            Key = "UpdateQuestion",
            PageType = new Uri("../Views/Template/TemplateQuestionAddOrUpdate.xaml", UriKind.Relative),
            Roles = new[] { "Manager", "Medewerker" }
        };

        public static Route TemplateQuestionAdd = new Route
        {
            Key = "AddQuestion",
            PageType = new Uri("../Views/Template/TemplateQuestionAdd.xaml", UriKind.Relative),
            Roles = new[] { "Manager", "Medewerker" }
        };

        #endregion

        #region Employee

        public static Route EmployeeList = new Route
        {
            Key = "EmployeeList",
            PageType = new Uri("../Views/Employee/EmployeeList.xaml", UriKind.Relative),
            Roles = new[] { "Manager" }
        };

        public static Route EmployeeAddOrUpdate = new Route
        {
            Key = "EmployeeAddOrUpdate",
            PageType = new Uri("../Views/Employee/EmployeeAddOrUpdate.xaml", UriKind.Relative),
            Roles = new[] { "Manager" }
        };

        public static Route InspectorList = new Route
        {
            Key = "InspectorList",
            PageType = new Uri("../Views/Inspector/InspectorList.xaml", UriKind.Relative),
            Roles = new[] { "Manager" }
        };

        public static Route InspectorAddOrUpdate = new Route
        {
            Key = "InspectorAddOrUpdate",
            PageType = new Uri("../Views/Inspector/InspectorAddOrUpdate.xaml", UriKind.Relative),
            Roles = new[] { "Manager" }
        };

        #endregion

        #region Inspection

        public static Route InspectionList = new Route
        {
            Key = "InspectionList",
            PageType = new Uri("../Views/InspectionList.xaml", UriKind.Relative),
            Roles = new[] { "Manager", "Medewerker" }
        };
        public static Route EditInspection = new Route
        {
            Key = "EditInspection",
            PageType = new Uri("../Views/EditInspection.xaml", UriKind.Relative),
            Roles = new[] { "Manager", "Medewerker" }
        };
        public static Route AddInspection = new Route
        {
            Key = "AddInspection",
            PageType = new Uri("../Views/AddInspection.xaml", UriKind.Relative),
            Roles = new[] { "Manager", "Medewerker" }
        };
        public static Route ProcessInspection = new Route
        {
            Key = "ProcessInspection",
            PageType = new Uri("../Views/ProcessInspection.xaml", UriKind.Relative),
            Roles = new[] { "Manager", "Medewerker" }
        };

        #endregion
    }
}