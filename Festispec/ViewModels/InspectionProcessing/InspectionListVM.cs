using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festispec.ViewModels.RequestProcessing
{
    public class InspectionListVM : ViewModelBase
    {
        // getters and setters
        public ObservableCollection<InspectionVM> InspectionVMList { get; set; }
        public ObservableCollection<string> FilterOptions { get; set; }
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
