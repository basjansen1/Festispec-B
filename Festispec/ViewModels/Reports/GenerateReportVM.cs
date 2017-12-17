using Festispec.Domain;
using Festispec.Domain.PDF;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Customer;
using Festispec.ViewModels.CustomerCRUD;
using Festispec.ViewModels.Employees;
using Festispec.ViewModels.InspectionProcessing;
using Festispec.ViewModels.PDF;
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

namespace Festispec.ViewModels.Reports
{
    public class GenerateReportVM : ViewModelBase
    {
        #region commands
        public ICommand DownloadCommand { get; set; }
        public ObservableCollection<InspectionVM> InspectionVMList { get; set; }
        public List<InspectionVM> InspectionList { get; set; }
        public List<int> OptionList { get; set; }
        public int SelectedAmount { get; set; }
        #endregion

        #region fields
        private InspectionResultsWriter _pdfWriter;
        private readonly INavigationService _navigationService;
        private CustomerViewModel _selectedCustomer;
        #endregion

        public GenerateReportVM(CustomerListViewModel customerList, INavigationService navigationService)
        {
            MessageBox.Show(customerList.SelectedCustomer.City);
            _navigationService = navigationService;

            _selectedCustomer = customerList.SelectedCustomer;

            OptionList = new List<int>()
            {
                1, 2, 3, 4, 5
            };

            DownloadCommand = new RelayCommand(Download);

            // Kan geen inspectionvm meesturen omdat die die niet kan importeren in de pdfwriter class.
            //_pdfWriter = new InspectionResultsWriter(InspectionVMList.ToList());
        }

        private void Download()
        {
            _navigationService.GoBack();
            //_pdfWriter.CreateDocument();

            if (InspectionVMList.Count < SelectedAmount)
            {
                MessageBox.Show("Er zijn niet zoveel inspecties");
                return;
            }

           // InspectionList = InspectionVMList.OrderByDescending(i => i.StartDate).ToList();
          //  InspectionList = InspectionVMList.Take(SelectedAmount).ToList();
           // InspectionList.Skip(Math.Max(0, InspectionList.Count() - SelectedAmount));
        }
    }
}
