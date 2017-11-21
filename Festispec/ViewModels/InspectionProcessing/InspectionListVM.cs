using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festispec.ViewModels.RequestProcessing
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

        // Commands
        public ICommand ShowAddInspectionWindowCommand;
        public ICommand ShowEditInspectionWindowCommand;
        public ICommand ShowProcessInspectionWindowCommand;
        public ICommand DeleteInspectionCommand;
        public ICommand FilterInspectionVMListCommand;

        // fields
        private InspectionVM _selectedInspection;
        private string _selectedFilterOption;
        private AddInspection _addInspectionView;
        private EditInspection _editInspectionView;
        private ProcessInspection _processInspectionView;

        // constructor
        public InspectionListVM(IInspectionRepositoryFactory inspectionRepositoryFactory)
        {
            List<InspectionVM> InspectionList;
            InspectionRepositoryFactory = inspectionRepositoryFactory;

            // instantiate commands 
            ShowAddInspectionWindowCommand = new RelayCommand(ShowAddInspectionWindow);
            ShowEditInspectionWindowCommand = new RelayCommand(ShowEditInspectionWindow);
            ShowProcessInspectionWindowCommand = new RelayCommand(ShowProcessInspectionWindow);
            DeleteInspectionCommand = new RelayCommand(DeleteSelectedInspection);
            
            // instantiate views
            
            
            

            using(var inspectionRepository = InspectionRepositoryFactory.CreateRepository())
            {
            //    InspectionList = inspectionRepository.Get().Select(i => new InspectionVM(i)).ToList();
            }

            // InspectionVMList = new ObservableCollection<InspectionVM>(InspectionList);
            InspectionVMList = new ObservableCollection<InspectionVM>();
        }

        // methods
        public void ShowAddInspectionWindow()
        {
            _addInspectionView = new AddInspection();
            _addInspectionView.Show();
        }

        public void HideAddInspectionWindow()
        {
            _addInspectionView.Hide();
        }

        public void ShowEditInspectionWindow()
        {
            _editInspectionView = new EditInspection();
            _editInspectionView.Show();
        }

        public void ShowProcessInspectionWindow()
        {
            _processInspectionView = new ProcessInspection();
            _processInspectionView.Show();
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
