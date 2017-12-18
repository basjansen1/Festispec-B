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
        public List<InspectionVM> InspectionVMList { get; set; }
        public List<int> OptionList { get; set; }
        public int SelectedAmount { get; set; }
        #endregion

        #region fields
        private InspectionResultsWriter _pdfWriter;
        private readonly INavigationService _navigationService;
        private CustomerViewModel _selectedCustomer;
        #endregion

        public GenerateReportVM(InspectionListVM inspectionList, CustomerViewModel customer, INavigationService navigationService)
        {
            MessageBox.Show(customer.City);
            _navigationService = navigationService;

            _selectedCustomer = customer;
            InspectionVMList = inspectionList.InspectionVMList.ToList();

            OptionList = new List<int>()
            {
                1, 2, 3, 4, 5
            };

            DownloadCommand = new RelayCommand(Download);

        }

        private void Download()
        {
            _navigationService.GoBack();

            if (InspectionVMList.Count < SelectedAmount)
            {
                MessageBox.Show("Er zijn niet zoveel inspecties");
                return;
            }

             InspectionVMList.Skip(Math.Max(0, InspectionVMList.Count() - SelectedAmount));
            _pdfWriter = new InspectionResultsWriter(InspectionVMList.Select(i => i.toModel()).ToList());

            _pdfWriter.CreateDocument();
        }
    }
}
