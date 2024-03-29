﻿using Festispec.Domain;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace Festispec.Domain.PDF
{
    public class InspectionResultsWriter : PDFWriter
    {
        private List<Inspection> _inspectionList;
        private Customer _customer;
        private ChartExporter _chart;

        public InspectionResultsWriter(List<Inspection> inspectionList, Customer customer)
        {
            _inspectionList = inspectionList;
            _customer = customer;

            _chart = new ChartExporter();
        }

        private void AddCoverPage()
        {
            for (int counter = 8; counter > 0; counter--)
            {
                AddEmptyLine();
            }
            AddLine("Inspectie resultaten", new XFont("Verdana", 35, XFontStyle.Bold));
            AddEmptyLine();
            AddLine("Periode: " + _inspectionList.Min(i => i.Start).ToShortDateString() + " - " + _inspectionList.Max(i => i.Start).ToShortDateString(), new XFont("Verdana", 16, XFontStyle.Bold));
            AddLine(_customer.Name, new XFont("Verdana", 16, XFontStyle.Bold));
            AddLine(_customer.Email, new XFont("Verdana", 16, XFontStyle.Bold));
            AddLine(_customer.Telephone, new XFont("Verdana", 16, XFontStyle.Bold));
            AddLine(_inspectionList.First().Street + ", " + _inspectionList.First().Municipality);
            AddNewPage();
        }

        private void AddIntroduction()
        {
            AddLine("In dit rapport zullen de resulataten van de inspecties uit de periode " +
                _inspectionList.Min(i => i.Start).ToShortDateString() + " - " + _inspectionList.Max(i => i.Start).ToShortDateString() +
                "  worden weergeven. Indien u verdere vragen heeft kunt u gerust contact met  ons opnemen.");
            AddNewPage();
        }

        private void AddQuestionAnswer(InspectionQuestion question)
        {
            AddQuestion(question);
            switch (question.Question.QuestionType_Type)
            {
                case "Tekst":
                    AddTextAnswer(question);
                    break;
                case "Getal":
                    AddNumberAnswer(question);
                    break;
                case "Reeks":
                    AddNumberAnswer(question);
                    break;
                case "Beeld":
                    AddPictureAnswer(question);
                    break;
                case "Tabel":
                    AddTableAnswer(question);
                    break;
                default:
                    AddTextAnswer(question);
                    break;
            }
        }

        private void AddPictureAnswer(InspectionQuestion question)
        {
            int i = 0;
            List<InspectionQuestionAnswer> l = question.InspectionQuestionAnswer.ToList();
            foreach (var answers in question.InspectionQuestionAnswer.Select(answer => answer.DeserializeBeeldAnswer()))
            {
                AddLine(l[i++].Planning.Inspector.FullName + ":");
                foreach (var splitAnswers in answers)
                {
                    string image = splitAnswers[0].Remove(splitAnswers[0].IndexOf("data:image/png;base64,"), "data:image/png;base64,".Length);
                    byte[] data = System.Convert.FromBase64String(image);
                    MemoryStream ms = new MemoryStream(data);
                    AddImage(Image.FromStream(ms));
                    AddLine(splitAnswers[1]);
                }
            }
        }

        private void AddTableAnswer(InspectionQuestion question)
        {
            List<string> series = new List<string>();
            string title = question.Question.Name;
            Dictionary<string, Dictionary<string, int>> xy = new Dictionary<string, Dictionary<string, int>>();

            var labels = new List<string>();
            var groups = new List<string>();
            var y = new List<List<int>>();

            foreach (var answers in question.InspectionQuestionAnswer.Select(answer => answer.DeserializeTabelAnswer()))
            {
                var extraLabels = answers.Select(row => row[0]).GroupBy(row => row).Select(row => row.First());
                foreach (var extraLabel in extraLabels)
                    if (!labels.Contains(extraLabel))
                        labels.Add(extraLabel);

                var extraGroups = answers.Select(row => row[1]).GroupBy(row => row).Select(row => row.First());
                foreach (var extraGroup in extraGroups)
                    if (!groups.Contains(extraGroup) && !string.IsNullOrWhiteSpace(extraGroup))
                        groups.Add(extraGroup);
            }


            foreach (var label in labels)
            {
                var z = new List<int>();
                foreach (var group in groups)
                {
                    foreach (var answers in question.InspectionQuestionAnswer.Select(answer => answer.DeserializeTabelAnswer()))
                    {
                        z.Add(answers.Count(row => row[0] == label && row[1] == group));
                    }
                }
                y.Add(z);
            }
            AddImage(_chart.GenerateChartFromTableQuestion(groups.ToList(), title, labels.ToList(), y));
        }

        private void AddQuestion(InspectionQuestion question)
        {
            AddParagraphTitle(question.Question.Name);
            AddEmptyLine();
        }

        private void AddNumberAnswer(InspectionQuestion question)
        {
            List<string> inspectors = new List<string>();
            string title = question.Question.Name;
            List<List<string>> y = new List<List<string>>();
            foreach (InspectionQuestionAnswer a in question.InspectionQuestionAnswer)
            {
                inspectors.Add(a.Planning.Inspector.FullName);
                y.Add(new List<string> {
                    a.Answer
                });
            }
            AddImage(_chart.GenerateChartFromQuestion(title, inspectors, y));
        }

        private void AddTextAnswer(InspectionQuestion question)
        {
            foreach (InspectionQuestionAnswer answer in question.InspectionQuestionAnswer)
            {
                AddLine(answer.Planning.Inspector.FullName + ": " + answer.Answer);
                AddEmptyLine();
            }
        }

        public void CreateDocument(string advise)
        {
            AddCoverPage();
            AddIntroduction();
            foreach (Inspection inspection in _inspectionList)
            {
                AddTitle("Inspectie " + inspection.Start.Date.ToShortDateString());
                foreach (InspectionQuestion inspectionQuestion in inspection.InspectionQuestion)
                {
                    AddQuestionAnswer(inspectionQuestion);
                }
            }
            AddAdvise(advise);
        }

        private void AddAdvise(string advise)
        {
            AddParagraphTitle("Advies:");
            if (advise != null)
            {
                AddLine(advise);
            } else
            {
                AddLine("Geen advies ingevoerd");
            }
            AddEmptyLine();
        }
    }
}
