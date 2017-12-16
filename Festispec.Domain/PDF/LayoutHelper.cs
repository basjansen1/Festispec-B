using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.ViewModels.PDF
{
    public class LayoutHelper
    {
        private readonly PdfDocument _document;
        private readonly XUnit _topPosition;
        private readonly XUnit _bottomMargin;
        private XUnit _currentPosition;
        private XUnit _left = XUnit.FromCentimeter(2.5);
        public int MarginBetweenLines { get; set; }
        public XFont Font { get; set; }
        public XSolidBrush Color { get; set; }
        public XStringFormat Allignment { get; set; }

        public LayoutHelper(PdfDocument document, XUnit topPosition, XUnit bottomMargin)
        {
            _document = document;
            _topPosition = topPosition;
            _bottomMargin = bottomMargin;
            CreatePage();
            MarginBetweenLines = 23;
            Color = XBrushes.Black;
            Allignment = XStringFormats.TopLeft;
            Font = new XFont("Verdana", 11);
        }

        public XGraphics Gfx { get; private set; }
        public PdfPage Page { get; private set; }

        public XUnit GetLinePosition(XUnit requestedHeight)
        {
            return GetLinePosition(requestedHeight, -1f);
        }

        public XUnit GetLinePosition(XUnit requestedHeight, XUnit requiredHeight)
        {
            XUnit required = requiredHeight == -1f ? requestedHeight : requiredHeight;
            if (_currentPosition + required > _bottomMargin)
                CreatePage();
            XUnit result = _currentPosition;
            _currentPosition += requestedHeight;
            return result;
        }

        public void CreatePage()
        {
            Page = _document.AddPage();
            Page.Size = PageSize.A4;
            Gfx = XGraphics.FromPdfPage(Page);
            _currentPosition = _topPosition;
        }

        public void TextToDocument(string text)
        {
            string[] wordList = text.Split(' ');
            string sentence = null;
            string tempSentence = null;
            
            foreach (string word in wordList)
            {
                tempSentence = tempSentence == null ? word : tempSentence + word + " ";

                if (Gfx.MeasureString(tempSentence, Font).Width > (Page.Width - _left)) // check whether a linebreak is needed
                {
                    DrawText(sentence);
                    sentence = word;
                    tempSentence = sentence;
                }
                else
                {
                    sentence = sentence + word + " ";
                }
            }
            DrawText(sentence); // draw last sentence
        }

        public void DrawText(string text)
        {
            XUnit top = GetLinePosition(MarginBetweenLines);
            Gfx.DrawString(text, Font, Color, _left, top, Allignment);
        }

        public void DrawImage(string pathToImage)
        {
            XImage image = XImage.FromFile(pathToImage);
            double imageWidth = image.PixelWidth;
            double imageHeight = image.PixelHeight;

            while (imageWidth > Page.Width - (_left * 2) || image.PixelHeight > Page.Height) // scale the image so that it fits within the page
            {
                imageWidth *= 0.9;
                imageHeight *= 0.9;
            }
            XUnit top = GetLinePosition(imageHeight);
            Gfx.DrawImage(image, _left, top, imageWidth, imageHeight);
            GetLinePosition(MarginBetweenLines); // provide space between the end of the image and the first text line
        }
    }
}
