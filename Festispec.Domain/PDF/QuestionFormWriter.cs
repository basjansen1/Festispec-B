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
    public class QuestionFormWriter : PDFWriter
    {
        public void SetTitle(string title)
        {
            SetDocumentTitle(title);
            AddEmptyLine();
        }

        public void AddParagraphHeader(string header)
        {
            AddParagraphTitle(header);
        }

        public void AddQuestion(string question)
        {
            AddLine(question, new XFont("Verdana", 12, XFontStyle.Bold));
        }

        public void AddAnswer(string answer)
        {
            AddLine(answer, new XFont("Verdana", 12, XFontStyle.Regular));
        }
    }
}
