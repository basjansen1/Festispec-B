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
        private void AddCoverPage()
        {

        }
        private void AddIntroduction()
        {

        }
        private void AddQuestion(string question)
        {
            SetFont(new XFont("Verdana", 16, XFontStyle.Bold));
            AddLine(question);
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

        }

    }
}
