using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.ViewModels.Regulation
{
    public class RegulationListVM
    {
        #region properties
        public ObservableCollection<RegulationVM> RegulationVMList { get; set; }
        #endregion

        #region fields
        private IRegulationRepositoryFactory _regulationRepositoryFactory;
        private INavigationService _navigationService;
        #endregion

        public RegulationListVM(IRegulationRepositoryFactory regulationRepositoryFactory, INavigationService navigationService)
        {
            _navigationService = navigationService;

            using (var regulationRepository = _regulationRepositoryFactory.CreateRepository())
            {
                RegulationVMList = new ObservableCollection<RegulationVM>(regulationRepository.Get().ToList().Select(i => new RegulationVM(i)));
            }
        }
    }
}
