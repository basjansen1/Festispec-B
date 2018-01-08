﻿using System;

namespace Festispec.Routes
{
    public static class Routes
    {
        public static Route Home = new Route
        {
            Key = "Home",
            PageType = new Uri("../MainWindow.xaml", UriKind.Relative),
            Offline = true
        };

        #region Template

        public static Route TemplateList = new Route
        {
            Key = "TemplateList",
            PageType = new Uri("../Views/Template/TemplateList.xaml", UriKind.Relative),
            Roles = new[] { "Manager", "Medewerker" }
        };

        public static Route TemplateAddOrUpdate = new Route
        {
            Key = "TemplateAddOrUpdate",
            PageType = new Uri("../Views/Template/TemplateAddOrUpdate.xaml", UriKind.Relative),
            Roles = new[] {"Manager", "Medewerker"}
        };

        #endregion

        #region Employee

        public static Route EmployeeList = new Route
        {
            Key = "EmployeeList",
            PageType = new Uri("../Views/Employee/EmployeeList.xaml", UriKind.Relative),
            Roles = new[] {"Manager"},
            Offline = true
        };

        public static Route EmployeeAddOrUpdate = new Route
        {
            Key = "EmployeeAddOrUpdate",
            PageType = new Uri("../Views/Employee/EmployeeAddOrUpdate.xaml", UriKind.Relative),
            Roles = new[] {"Manager"}
        };

        #endregion

        #region Inspector


        public static Route InspectorList = new Route
        {
            Key = "InspectorList",
            PageType = new Uri("../Views/Inspector/InspectorList.xaml", UriKind.Relative),
            Roles = new[] {"Manager"},
            Offline = true
        };

        public static Route InspectorAddOrUpdate = new Route
        {
            Key = "InspectorAddOrUpdate",
            PageType = new Uri("../Views/Inspector/InspectorAddOrUpdate.xaml", UriKind.Relative),
            Roles = new[] {"Manager"}
        };

        #endregion

        #region Customer

        public static Route CustomerList = new Route
        {
            Key = "CustomerList",
            PageType = new Uri("../Views/CustomerCRUD/CustomerList.xaml", UriKind.Relative),
            Roles = new[] {"Manager"},
            Offline = true
        };

        public static Route CustomerAddOrUpdate = new Route
        {
            Key = "CustomerAddOrUpdate",
            PageType = new Uri("../Views/CustomerCRUD/CustomerAddOrUpdate.xaml", UriKind.Relative),
            Roles = new[] {"Manager"}
        };

        #endregion




        #region Planning

        public static Route PlanningList = new Route
        {
            Key = nameof(PlanningList),
            PageType = new Uri("../Views/Planning/PlanningList.xaml", UriKind.Relative),
            Roles = new[] {"Manager", "Medewerker"},
            Offline = true
        };

        public static Route PlanningAdd = new Route
        {
            Key = nameof(PlanningAdd),
            PageType = new Uri("../Views/Planning/PlanningAdd.xaml", UriKind.Relative),
            Roles = new[] {"Manager", "Medewerker"}
        };

        public static Route PlanningUpdate = new Route
        {
            Key = nameof(PlanningUpdate),
            PageType = new Uri("../Views/Planning/PlanningUpdate.xaml", UriKind.Relative),
            Roles = new[] {"Manager", "Medewerker"}
        };

        #endregion









        #region Inspection

        public static Route InspectionList = new Route
        {
            Key = "InspectionList",
            PageType = new Uri("../Views/InspectionList.xaml", UriKind.Relative),
            Roles = new[] {"Manager", "Medewerker"},
            Offline = true
        };

        public static Route EditInspection = new Route
        {
            Key = "EditInspection",
            PageType = new Uri("../Views/EditInspection.xaml", UriKind.Relative),
            Roles = new[] {"Manager", "Medewerker"}
        };

        public static Route AddInspection = new Route
        {
            Key = "AddInspection",
            PageType = new Uri("../Views/AddInspection.xaml", UriKind.Relative),
            Roles = new[] {"Manager", "Medewerker"}
        };

        public static Route ProcessInspection = new Route
        {
            Key = "ProcessInspection",
            PageType = new Uri("../Views/ProcessInspection.xaml", UriKind.Relative),
            Roles = new[] {"Manager", "Medewerker"}
        };

        #endregion

        #region Regulation

        public static Route ShowRegulation = new Route
        {
            Key = "ShowRegulation",
            PageType = new Uri("../Views/ShowRegulation.xaml", UriKind.Relative),
            Roles = new[] {"Manager", "Medewerker"},
            Offline = true
        };

        public static Route RegulationList = new Route
        {
            Key = "RegulationList",
            PageType = new Uri("../Views/Regulations/RegulationList.xaml", UriKind.Relative),
            Roles = new[] {"Manager", "Medewerker"},
            Offline = true
        };

        public static Route RegulationAddOrUpdate = new Route
        {
            Key = "RegulationAddOrUpdate",
            PageType = new Uri("../Views/Regulations/RegulationAddOrUpdate.xaml", UriKind.Relative),
            Roles = new[] {"Manager", "Medewerker"}
        };

        public static Route InspectorSchedule = new Route
        {
            Key = "InspectorSchedule",
            PageType = new Uri("../Views/Inspector/Schedule/InspectorSchedule.xaml", UriKind.Relative),
            Roles = new[] { "Manager" }
        };

        public static Route InspectorScheduleAddOrUpdate = new Route
        {
            Key = "InspectorScheduleAddOrUpdate",
            PageType = new Uri("../Views/Inspector/Schedule/InspectorScheduleAddOrUpdate.xaml", UriKind.Relative),
            Roles = new[] { "Manager" }
        };

        public static Route InspectorScheduleAdd = new Route
        {
            Key = "InspectorScheduleAdd",
            PageType = new Uri("../Views/Inspector/Schedule/InspectorScheduleAdd.xaml", UriKind.Relative),
            Roles = new[] { "Manager" }
        };
        #endregion
        
        #region reports

        public static Route Reports = new Route
        {
            Key = "Reports",
            PageType = new Uri("../Views/CustomerReportView.xaml", UriKind.Relative),
            Roles = new[] { "Manager", "Medewerker" },
            Offline = true
        };


        public static Route GenerateReport = new Route
        {
            Key = "GenerateReport",
            PageType = new Uri("../Views/GenerateReport.xaml", UriKind.Relative),
            Roles = new[] { "Manager", "Medewerker" },
            Offline = true
        };
        

        #endregion

        public static Route QuestionAdd = new Route()
        {
            Key = "QuestionAdd",
            PageType = new Uri("../Views/Question/QuestionAdd.xaml", UriKind.Relative),
            Roles = new[] {"Manager", "Medewerker"}
        };

        public static Route InspectionQuestionnaire = new Route()
        {
            Key = "InspectionQuestionnaire",
            PageType = new Uri("../Views/Inspection/InspectionQuestionnaire.xaml", UriKind.Relative),
            Roles = new[] { "Manager", "Medewerker" }
        };

        public static Route MapOverview = new Route()
        {
            Key = "MapOverview",
            PageType = new Uri("../Views/Map/MapOverview.xaml", UriKind.Relative),
            Roles = new[] { "Manager", "Medewerker" }
        };

    }
}