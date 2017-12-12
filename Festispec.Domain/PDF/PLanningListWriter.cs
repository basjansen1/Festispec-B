using Festispec.ViewModels.PDF;
using PdfSharp.Charting;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.Domain.PDF
{
    public class PLanningListWriter : PDFWriter
    {
        private List<Planning> _planningList;

        public PLanningListWriter()
        {
            _planningList = new List<Planning>();

            Planning planning = new Planning();
            planning.Date = DateTime.Now;
            planning.Inspection_Id = 1;
            planning.Inspector_Id = 2;
            planning.TimeFrom = new TimeSpan(1, 1, 1);
            planning.TimeTo = new TimeSpan(2, 2, 2);
            planning.Inspection = new Inspection() { Name = "Inspection 1", Website = "www.festispec.nl", Start = DateTime.Now, End = DateTime.Now, Status_Status = "Pending", Customer_Id = 11 };
            planning.Inspector = new Inspector() { FirstName = "TestVoornaam", LastName = "TestAchternaam", Telephone = "0610002000" };

            _planningList.Add(planning);
            _planningList.Add(planning);
            _planningList.Add(planning);
            _planningList.Add(planning);
            _planningList.Add(planning);
        }
        public void SetTitle(string title)
        {
            SetDocumentTitle(title);
        }

        public void AddParagraphHeader(string header)
        {
         //   AddEmptyLine();
            AddParagraphTitle(header);
        }

        public void AddInspectorData(Inspector inspector)
        {
            if (inspector != null)
            {
                AddLine("Name: " + inspector.FirstName + " " + inspector.LastName);
                AddLine("Telephone number: " + inspector.Telephone);
            }
        }

        public void AddPlanningData(Planning Planning)
        {
            AddLine("Start at: " + Planning.TimeFrom);
            AddLine("Ends at: " + Planning.TimeTo);
            AddLine("Length: " + Planning.Hours + " hours");
        }

        public void AddInspectionData(Inspection Inspection)
        {
            if (Inspection != null)
            {
                AddLine("Company name: " + Inspection.Name);
                AddLine("Company website: " + Inspection.Website);
            }
        }

        public void CreateDocument()
        {
            this.SetTitle("Plannings");
            AddEmptyLine();
            foreach (Planning planning in _planningList)
            {
                AddParagraphHeader("Planning information Planning information Planning information Planning information Planning information"); // + planning.Date
                AddPlanningData(planning);
                AddParagraphHeader("Inspection information");
                AddInspectionData(planning.Inspection);
                AddParagraphHeader("Inspector information: ");
                AddInspectorData(planning.Inspector);
            }
            SaveAs("AllPlanningInformation");
            OpenDocument("AllPlanningInformation");
        }
    }
}
