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
        public void SetTitle(string title)
        {

        }
    }
}
