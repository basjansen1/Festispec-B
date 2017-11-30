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

        #endregion

        #region Inspector


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

        #region Schedule
        public static Route ScheduleList = new Route
        {
            Key = "ScheduleList",
            PageType = new Uri("../Views/Schedule/ScheduleList.xaml", UriKind.Relative),
            Roles = new[] { "Manager", "Inspecteur", "Medewerker" }
        };

        public static Route ScheduleUpdate = new Route
        {
            Key = "ScheduleUpdate",
            PageType = new Uri("../Views/Schedule/ScheduleUpdate.xaml", UriKind.Relative),
            Roles = new[] { "Manager", "Inspecteur", "Medewerker" }
        };

        public static Route ScheduleView = new Route
        {
            Key = "ScheduleView",
            PageType = new Uri("../Views/Schedule/ScheduleView.xaml", UriKind.Relative),
            Roles = new[] { "Manager", "Inspecteur", "Medewerker" }
        };
        #endregion

    }
}