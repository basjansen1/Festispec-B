using Festispec.Domain.Repository.Factory.Interface;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;

namespace Festispec.ViewModels.Inspection
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
        public ICommand ShowRegulationCommand { get; set; }
        public ICommand ShowProcessInspectionWindowCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand DeleteSearchCommand { get; set; }
        public ICommand NavigateToPlanningCommand { get; set; }
        public ICommand NavigateToQuestionnaireCommand { get; set; }
        #endregion

        #region fields
        private InspectionVM _selectedInspection;
        private List<InspectionVM> _inspectionList;
        private readonly INavigationService _navigationService;
        private readonly IInspectionViewModelFactory _inspectionViewModelFactory;
        #endregion

        // constructor
        public InspectionListVM(IInspectionRepositoryFactory inspectionRepositoryFactory, IInspectionViewModelFactory inspectionViewModelFactory, INavigationService navigationService)
        {
            InspectionRepositoryFactory = inspectionRepositoryFactory;
            _inspectionViewModelFactory = inspectionViewModelFactory;
            _navigationService = navigationService;
            _inspectionList = new List<InspectionVM>();

            // instantiate commands 
            ShowAddInspectionWindowCommand = new RelayCommand(ShowAddInspectionWindow, () => _navigationService.CanAndHasAccess(Routes.Routes.AddInspection));
            ShowEditInspectionWindowCommand = new RelayCommand(ShowEditInspectionWindow, () => SelectedInspection != null && _navigationService.CanAndHasAccess(Routes.Routes.EditInspection));
            ShowProcessInspectionWindowCommand = new RelayCommand(ShowProcessInspectionWindow, () => SelectedInspection != null && _navigationService.CanAndHasAccess(Routes.Routes.ProcessInspection));
            ShowRegulationCommand = new RelayCommand(OpenRegulation, () => SelectedInspection != null && _navigationService.CanAndHasAccess(Routes.Routes.ShowRegulation));
            SearchCommand = new RelayCommand(Search);
            DeleteSearchCommand = new RelayCommand(DeleteFilter);
            NavigateToPlanningCommand = new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.PlanningList, _selectedInspection.toModel()), () => _selectedInspection != null && _navigationService.CanAndHasAccess(Routes.Routes.PlanningList));
            _searchInput = null;
            NavigateToQuestionnaireCommand = new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.InspectionQuestionnaire, _selectedInspection), () => _selectedInspection != null && _navigationService.CanAndHasAccess(Routes.Routes.InspectionQuestionnaire));
            _searchInput = null;

            // instantiate views   
            using (var inspectionRepository = InspectionRepositoryFactory.CreateRepository())
            {
                 InspectionVMList = new ObservableCollection<InspectionVM>(inspectionRepository.Get().ToList().Select(_inspectionViewModelFactory.CreateViewModel));
            }            
        }

        #region methods
        public void ShowAddInspectionWindow()
        {
            _navigationService.NavigateTo(Routes.Routes.AddInspection);
        }

        private void OpenRegulation()
        {
            _navigationService.NavigateTo(Routes.Routes.ShowRegulation, SelectedInspection.Municipality);
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
            if (SearchInput == null) return;

            ReloadInspectionVmList();
            _inspectionList.Clear();
            InspectionVMList.ToList().ForEach(n => _inspectionList.Add(n));
            InspectionVMList.Clear();

            foreach(InspectionVM i in _inspectionList)
            {
                if (i.Name != null && i.Name.ToLower().Contains(SearchInput.ToLower()) ||
                    i.Customer.Name != null && i.Customer.Name.ToLower().Contains(SearchInput.ToLower()) ||
                    i.City != null && i.City.ToLower().Contains(SearchInput.ToLower()) ||
                    i.Municipality != null && i.Municipality.ToLower().Contains(SearchInput.ToLower()) ||
                    i.Status != null && i.Status.ToLower().Contains(SearchInput.ToLower()))
                {
                    InspectionVMList.Add(i);
                }
            }
        }

        public void ReloadInspectionVmList()
        {
            using (var inspectionRepository = InspectionRepositoryFactory.CreateRepository())
            {
                InspectionVMList.Clear();
                inspectionRepository.Get().ToList().ForEach(i => InspectionVMList.Add(_inspectionViewModelFactory.CreateViewModel(i)));
            }
        }
        private void DeleteFilter()
        {
            ReloadInspectionVmList();
            SearchInput = null;
        }
        #endregion
    }
}