using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Employees;
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

namespace Festispec.ViewModels.Regulation
{
    public class RegulationListVM : ViewModelBase
    {
        #region properties
        public ObservableCollection<RegulationVM> RegulationVMList { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        public RegulationVM SelectedRegulation
        {
            get
            {
                return _selectedRegulation;
            }
            set
            {
                _selectedRegulation = value;
                RaisePropertyChanged("SelectedInspection");
            }
        }
        #endregion

        #region fields
        private IRegulationRepositoryFactory _regulationRepositoryFactory;
        private INavigationService _navigationService;
        private string _municipality;
        private RegulationVM _selectedRegulation;
        #endregion

        public RegulationListVM(IRegulationRepositoryFactory regulationRepositoryFactory, INavigationService navigationService, InspectionListVM inspectionList)
        {
            _navigationService = navigationService;
            _regulationRepositoryFactory = regulationRepositoryFactory;
            _municipality = inspectionList.SelectedInspection.Municipality;

            CloseWindowCommand = new RelayCommand(_navigationService.GoBack);

            using (var regulationRepository = _regulationRepositoryFactory.CreateRepository())
            {
                RegulationVMList = new ObservableCollection<RegulationVM>(regulationRepository.Get().ToList()
                                    .Where(i => i.Municipality == _municipality || String.IsNullOrEmpty(i.Municipality))
                                    .Select(i => new RegulationVM(i)));
            }
        }
    }
}
