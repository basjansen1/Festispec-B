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
        #region properties
        public ObservableCollection<InspectionVM> InspectionVMList { get; set; }
        public string SearchInput
        {
            get
            {
                return _searchInput;
            }
            set
            {
                _searchInput = value;
                RaisePropertyChanged("SearchInput");
            }
        }
        private string _searchInput;
        public IInspectionRepositoryFactory InspectionRepositoryFactory;

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

        #endregion

        #region Commands
        public ICommand ShowAddInspectionWindowCommand { get; set; }
        public ICommand ShowEditInspectionWindowCommand { get; set; }
        public ICommand ShowProcessInspectionWindowCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand DeleteSearchCommand { get; set; }
        #endregion

        #region fields
        private InspectionVM _selectedInspection;
        private List<InspectionVM> _inspectionList;
        private readonly INavigationService _navigationService;
        #endregion

        // constructor
        public InspectionListVM(IInspectionRepositoryFactory inspectionRepositoryFactory, INavigationService navigationService)
        {
            InspectionRepositoryFactory = inspectionRepositoryFactory;
            _navigationService = navigationService;
            _inspectionList = new List<InspectionVM>();

            // instantiate commands 
            ShowAddInspectionWindowCommand = new RelayCommand(ShowAddInspectionWindow);
            ShowEditInspectionWindowCommand = new RelayCommand(ShowEditInspectionWindow);
            ShowProcessInspectionWindowCommand = new RelayCommand(ShowProcessInspectionWindow);
            SearchCommand = new RelayCommand(Search);
            DeleteSearchCommand = new RelayCommand(DeleteFilter);
            _searchInput = null;

            // instantiate views   
            using (var inspectionRepository = InspectionRepositoryFactory.CreateRepository())
            {
                 InspectionVMList = new ObservableCollection<InspectionVM>(inspectionRepository.Get().ToList().Select(i => new InspectionVM(i)));
            }            
        }

        #region methods
        public void ShowAddInspectionWindow()
        {
            _navigationService.NavigateTo(Routes.Routes.AddInspection);
        }

        public void ShowEditInspectionWindow()
        {
            if (_selectedInspection != null)
                _navigationService.NavigateTo(Routes.Routes.EditInspection);
            else
                MessageBox.Show("Je moet eerst een inspectie selecteren!");
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

        private void Search()
        {
            if (SearchInput != null)
            {
                ReloadInspectionVMList();
                _inspectionList.Clear();
                InspectionVMList.ToList().ForEach(n => _inspectionList.Add(n));
                InspectionVMList.Clear();

                foreach(InspectionVM i in _inspectionList)
                {
                    if (i.Name.ToLower().Contains(SearchInput.ToLower()) ||  i.Customer.Name.ToLower().Contains(SearchInput.ToLower()) || 
                        i.City.ToLower().Contains(SearchInput.ToLower()) || i.Municipality.ToLower().Contains(SearchInput.ToLower()))
                    {
                        InspectionVMList.Add(i);
                    }
                }
            }
        }

        private void ReloadInspectionVMList()
        {
            using (var inspectionRepository = InspectionRepositoryFactory.CreateRepository())
            {
                InspectionVMList.Clear();
                inspectionRepository.Get().ToList().ForEach(i => InspectionVMList.Add(new InspectionVM(i)));
            }
        }
        private void DeleteFilter()
        {
            ReloadInspectionVMList();
            SearchInput = null;
        }
        #endregion
    }
}