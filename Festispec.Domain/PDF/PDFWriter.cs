using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Drawing;

namespace Festispec.Domain.PDF
{
    public abstract class PDFWriter
    {
        protected PdfDocument _document;
        private LayoutHelper _helper;

        public PDFWriter()
        {
            _document = new PdfDocument();
            // Use standard A4, page height is 29.7 cm. Use margins of 2.5 cm.
            _helper = new LayoutHelper(_document, XUnit.FromCentimeter(2.5), XUnit.FromCentimeter(29.7 - 2.5));
        }
        public void AddTitle(string title)
        {
            SetFont(new XFont("Verdana", 20, XFontStyle.Bold));
            AddText(title);
        }

        public void AddLine(string sentence)
        {
            SetFont(new XFont("Verdana", 12, XFontStyle.Regular));
            AddText(sentence);
        }

        public void AddLine(string sentence, XFont font)
        {
            SetFont(font);
            AddText(sentence);
        }

        public void AddEmptyLine()
        {
            AddText("");
        }

        public void AddParagraphTitle(string header)
        {
            SetFont(new XFont("Verdana", 16, XFontStyle.Regular));
            AddText(header);
        }

        private void AddText(string text)
        {
            _helper.TextToDocument(text);
        }

        public void AddImage(Image image)
        {
            _helper.DrawImage(image);
        }

        public void AddNewPage()
        {
            _helper.CreatePage();
        }

        public void SetFont(XFont font)
        {
            _helper.Font = font;
        }

        public void SetColor(XSolidBrush color)
        {
            _helper.Color = color;
        }

        public void Save(string path)
        {
            _document.Save(path + ".pdf");
        }

        public void OpenDocument(string documentTitle) // TestMethod
        {
            Process.Start(documentTitle + ".pdf");
        }
    }
}
