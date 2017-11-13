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
        public ObservableCollection<string> FilterOptions { get; set; } // not sure whether this variable will be in this class
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

        public string SelectedFilterOption
        {
            get
            {
                return _selectedFilterOption;
            }
            set
            {
                _selectedFilterOption = value;
                RaisePropertyChanged("SelectedFilterOption");
                this.FilterInspectionVMList();
            }
        }

        // Commands
        public ICommand ShowAddInspectionWindowCommand;
        public ICommand ShowEditInspectionWindowCommand;
        public ICommand ShowProcessInspectionWindowCommand;
        public ICommand DeleteInspectionCommand;
        public ICommand FilterInspectionVMListCommand;
        public ICommand SearchInspectionCommand;

        // fields
        private InspectionVM _selectedInspection;
        private string _selectedFilterOption;

        // constructor
        public InspectionListVM()
        {
            InspectionVMList = new ObservableCollection<InspectionVM>();

            // instantiate commands 
            ShowAddInspectionWindowCommand = new RelayCommand(ShowAddInspectionWindow);
            ShowEditInspectionWindowCommand = new RelayCommand(ShowEditInspectionWindow);
            ShowProcessInspectionWindowCommand = new RelayCommand(ShowProcessInspectionWindow);
            DeleteInspectionCommand = new RelayCommand(DeleteSelectedInspection);
            FilterInspectionVMListCommand = new RelayCommand(FilterInspectionVMList);
            SearchInspectionCommand = new RelayCommand(RenderSearchedInspection);
        }

        // methods
        public void ShowAddInspectionWindow()
        {
           
        }

        public void HideAddInspectionWindow()
        {

        }

        public void ShowEditInspectionWindow()
        {

        }

        public void ShowProcessInspectionWindow()
        {

        }

        public void DeleteSelectedInspection()
        {

        }

        public void FilterInspectionVMList()
        {

        }

        public void RenderSearchedInspection()
        {

        }
    }
}
