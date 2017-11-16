using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.ViewModels.PDF
{
    public abstract class PDFWriter
    {
        private PdfDocument document;
        private string _title;
        private XFont _font;

        public PDFWriter()
        {
            document = new PdfDocument();
        }
        public void SetTitle(string title)
        {
            _font = new XFont("Verdana", 20, XFontStyle.Bold);
        }

        public void AddText(string text)
        {

        }

        public void AddHeader() { }

        public void ChangeFont()
        {

        }
    }
}
