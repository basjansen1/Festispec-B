using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.InspectionProcessing;
using Festispec.Views;
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
using Festispec.NavigationService;

namespace Festispec.ViewModels.Employees
{
    // The view variables and view methods will be implemented when the views are created
    public class InspectionListVM : ViewModelBase
    {
        // getters and setters
        public ObservableCollection<InspectionVM> InspectionVMList { get; set; }


        public InspectionVM SelectedInspection
        {
            get
            {
                return _selectedInspection;
            }
            set
            {
                _selectedInspection = value;
                RaisePropertyChanged("SelectedInspection");
            }
        }

        public IInspectionRepositoryFactory InspectionRepositoryFactory;
        private readonly INavigationService _navigationService;

        // Commands
        public ICommand ShowAddInspectionWindowCommand { get; set; }
        public ICommand ShowEditInspectionWindowCommand { get; set; }
        public ICommand ShowProcessInspectionWindowCommand { get; set; }
        public ICommand DeleteInspectionCommand { get; set; }


        // fields
        private InspectionVM _selectedInspection;

        private AddInspection _addInspectionView;
        private EditInspection _editInspectionView;
        private ProcessInspection _processInspectionView;

        // constructor
        public InspectionListVM(IInspectionRepositoryFactory inspectionRepositoryFactory, INavigationService navigationService)
        {
            InspectionRepositoryFactory = inspectionRepositoryFactory;
            _navigationService = navigationService;

            // instantiate commands 
            ShowAddInspectionWindowCommand = new RelayCommand(ShowAddInspectionWindow);
            ShowEditInspectionWindowCommand = new RelayCommand(ShowEditInspectionWindow);
            ShowProcessInspectionWindowCommand = new RelayCommand(ShowProcessInspectionWindow);
            DeleteInspectionCommand = new RelayCommand(DeleteSelectedInspection);

            // instantiate views   
            using (var inspectionRepository = InspectionRepositoryFactory.CreateRepository())
            {
                 InspectionVMList = new ObservableCollection<InspectionVM>(inspectionRepository.Get().ToList().Select(i => new InspectionVM(i)));
            }            

        }

        // methods
        public void ShowAddInspectionWindow()
        {
            _navigationService.NavigateTo(Routes.Routes.AddInspection);
        }

        public void ShowEditInspectionWindow()
        {
            _navigationService.NavigateTo(Routes.Routes.EditInspection);
        }

        public void ShowProcessInspectionWindow()
        {
            _navigationService.NavigateTo(Routes.Routes.ProcessInspection);
        }

        public void DeleteSelectedInspection()
        {
            using(var inspectionRepository = InspectionRepositoryFactory.CreateRepository())
            {
                inspectionRepository.Delete(SelectedInspection.toModel());
            }
            this.InspectionVMList.Remove(SelectedInspection);
        }
    }
}
