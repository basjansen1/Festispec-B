using Festispec.Domain;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Festispec.Domain.PDF
{
    public class InspectionResultsWriter : PDFWriter
    {
        private List<Inspection> _inspectionList;
        private string _customerName;
        private ChartExporter _chart;
        
        public InspectionResultsWriter(List<Inspection> inspectionList, string customerName)
        {
            _inspectionList = inspectionList;
            _customerName = customerName;

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
            AddLine("Periode: " +_inspectionList.Min(i => i.Start).ToShortDateString() + " - " + _inspectionList.Max(i => i.Start).ToShortDateString(), new XFont("Verdana", 16, XFontStyle.Bold));
            AddLine(_customerName, new XFont("Verdana", 16, XFontStyle.Bold));
            AddNewPage();
        }

        private void AddIntroduction()
        {
            AddLine("In dit rapport zullen de resulataten van de inspecties uit de periode " +
                _inspectionList.Min(i => i.Start).ToShortDateString() + " - " + _inspectionList.Max(i => i.Start).ToShortDateString() +
                "  worden weergeven. Indien u verdere vragen heeft kunt u gerust contact met  ons opnemen.");
            AddNewPage();
        }

        private void AddQuestion(string question)
        {
            AddParagraphTitle(question);
            AddEmptyLine();

        }

        private void AddAnswer(string answer)
        {
            AddLine(answer);
            AddEmptyLine();
        }

        private void AddComment(string comment)
        {
            AddLine(comment);
            AddEmptyLine();
        }

        public void CreateDocument()
        {
            this.AddCoverPage();
            this.AddIntroduction();
            foreach (Inspection inspection in _inspectionList)
            {
                AddTitle("Inspectie " + inspection.Start.Date.ToShortDateString());
                foreach(InspectionQuestion question in inspection.InspectionQuestion)
                {
                    AddAnswer(question.Question.Name);
                }
                // Todo: print question and answer(chart)
                //this.GenerateChart(new string[1] { inspection.Name } );
            }
        }

        private void GenerateChart(string[] inspectionName, string inspectiontitle, string label, string answer)
        {
          //  _chart.GenerateChart(_inspectionList.First().Id )
        }

    }
}
