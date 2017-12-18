using Festispec.Domain;
using Festispec.Domain.PDF;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Customer;
using Festispec.ViewModels.CustomerCRUD;
using Festispec.ViewModels.Employees;
using Festispec.ViewModels.InspectionProcessing;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _inspectionVMList = inspectionList.InspectionVMList.ToList();

            MessageBox.Show(_inspectionVMList.Count.ToString());

            SelectedAmount = 1;

            OptionList = new List<int>()
            {
                1, 2, 3, 4, 5
            };

            DownloadCommand = new RelayCommand(Download);
        }

        private void Download()
        {
            _inspectionVMList = _inspectionVMList.Where(i => i.Name == _selectedCustomer.Name).ToList();

            if (_inspectionVMList.Count < SelectedAmount)
            {
                MessageBox.Show("Er zijn niet zoveel inspecties");
                return;
            }
            _inspectionVMList = _inspectionVMList.Skip(Math.Max(0, _inspectionVMList.Count() - SelectedAmount)).ToList();

            _pdfWriter = new InspectionResultsWriter(_inspectionVMList.Select(i => i.toModel()).ToList(), _selectedCustomer.Name);

            // create document
            try
            {
                _pdfWriter.CreateDocument();
            } catch
            {
                MessageBox.Show("Er kan geen rapport gegeneerd worden");
                _navigationService.GoBack();
            }

            // open filechooser
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Naam"; 
            dlg.DefaultExt = ".pdf"; // 
            dlg.Filter = "PDF documents (.pdf)|*.pdf";
            string filename = null;
            
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            { 
                filename = dlg.FileName;

                // Save document
                try
                {
                    _pdfWriter.Save(filename);
                    _pdfWriter.OpenDocument("testdocument"); // Test methode, remove this when finished
                }
                catch
                {
                    MessageBox.Show("Kan het document niet opslaan op deze locatie");
                    _navigationService.GoBack();
                }
                MessageBox.Show("Het rapport is opgeslagen");
            }
            _navigationService.GoBack();
        }
    }
}
