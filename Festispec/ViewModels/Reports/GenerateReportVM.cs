using Festispec.Domain.PDF;
using Festispec.NavigationService;
using Festispec.ViewModels.Customer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Festispec.ViewModels.Inspection;

namespace Festispec.ViewModels.Reports
{
    public class GenerateReportVM : ViewModelBase
    {
        #region commands
        public ICommand DownloadCommand { get; set; }
        public List<int> OptionList { get; set; }
        public int SelectedAmount { get; set; }

        public string Advise { get; set; }
        #endregion

        #region fields
        private InspectionResultsWriter _pdfWriter;
        private readonly INavigationService _navigationService;
        private CustomerViewModel _selectedCustomer;
        private List<InspectionVM> _inspectionVMList { get; set; }

        #endregion

        public GenerateReportVM(InspectionListVM inspectionList, CustomerViewModel customer, INavigationService navigationService)
        {
            _navigationService = navigationService;

            _selectedCustomer = customer;
            _inspectionVMList = inspectionList.InspectionVMList.Where(i => i.CustomerId == _selectedCustomer.Id).ToList();
            SelectedAmount = 1;

            OptionList = new List<int>();
            int j = 1;
            foreach(InspectionVM ins in _inspectionVMList)
            {
                OptionList.Add(j++);
            }
            DownloadCommand = new RelayCommand(Download);
        }

        private void Download()
        {
            _inspectionVMList.OrderBy(i => i.Id).Reverse();
            
            _inspectionVMList = _inspectionVMList.Skip(Math.Max(0, _inspectionVMList.Count() - SelectedAmount)).ToList();

            _pdfWriter = new InspectionResultsWriter(_inspectionVMList.Select(i => i.toModel()).ToList(), _selectedCustomer.Entity);
            
            _pdfWriter.CreateDocument(Advise);

            // open filechooser
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = _inspectionVMList.First().Customer.Name + _inspectionVMList.First().Name; 
            dlg.DefaultExt = ".pdf";
            dlg.Filter = "PDF documents (.pdf)|*.pdf";
            string filename = null;
            
            bool? result = dlg.ShowDialog();

            if (result == true)
            { 
                filename = dlg.FileName;

                // Save document
                try
                {
                    _pdfWriter.Save(filename);
                    MessageBox.Show("Het rapport is opgeslagen");
                }
                catch
                {
                    MessageBox.Show("Kan het document niet opslaan op deze locatie");
                    _navigationService.GoBack();
                }
            }
            _navigationService.GoBack();
        }
    }
}
