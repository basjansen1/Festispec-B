using Festispec.Domain.PDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = new PLanningListWriter();
            writer.CreateDocument();
        }
    }
}
