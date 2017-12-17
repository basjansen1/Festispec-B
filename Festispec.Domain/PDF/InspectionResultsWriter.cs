using Festispec.Domain;
using Festispec.ViewModels.PDF;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.Domain.PDF
{
    public class InspectionResultsWriter : PDFWriter
    {
        private List<Inspection> _inspectionList;
        private Customer _customer;

        public InspectionResultsWriter(List<Inspection> inspectionList, Customer customer)
        {
            _inspectionList = inspectionList;
            _customer = customer;
        }

        public InspectionResultsWriter(List<Inspection> inspectionList)
        {
            _inspectionList = inspectionList;
        }

        private void AddCoverPage()
        {
            for (int counter = 8; counter > 0; counter--)
            {
                AddEmptyLine();
            }
            AddLine("Inspectie resultaten " + _inspectionList.Min(i => i.Dates) + " - " + _inspectionList.Max(i => i.Dates), new XFont("Verdana", 35, XFontStyle.Bold));
            AddLine(_customer.Name, new XFont("Verdana", 16, XFontStyle.Bold));
            AddLine(_customer.KVK, new XFont("Verdana", 16, XFontStyle.Bold));
            AddNewPage();
        }

        private void AddIntroduction()
        {
            AddLine("In deze rapport zullen de resulataten van de inspecties uit de periode " +
                _inspectionList.Min(i => i.Dates) + " - " + _inspectionList.Max(i => i.Dates) +
                " worden weergeven. Indien u verdere vragen heeft kunt u gerust contact met ons opnemen.");
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
                AddTitle("Inspectie " + inspection.Dates);
                // Todo: print question and answer(chart)
            }
        }

    }
}
