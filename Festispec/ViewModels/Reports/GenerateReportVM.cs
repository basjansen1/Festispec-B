using Festispec.Domain;
using Festispec.Domain.PDF;
using Festispec.ViewModels.Employees;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Festispec.ViewModels.Reports
{
    public class GenerateReportVM : ViewModelBase
    {
        public ICommand DownloadCommand { get; set; }
        public List<Inspection> InspectionList { get; set; }
        private InspectionResultsWriter _pdfWriter;

        public GenerateReportVM(List<Inspection> inspectionList)
        {
            DownloadCommand = new RelayCommand(Download);
            _pdfWriter = new InspectionResultsWriter(InspectionList);
            InspectionList = inspectionList;

            if (InspectionList.Count == 0) MessageBox.Show("LEEG");
        }

        private void Download()
        {
            _pdfWriter.CreateDocument();
        }
    }
}
