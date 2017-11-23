using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.NavigationService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.ViewModels.CustomerCRUD
{
    class CustomerAddOrUpdateViewModel
    {


        public CustomerAddOrUpdateViewModel(INavigationService navigationService,
            ICustomerRepositoryFactory repositoryFactory,
            ICustomerRoleRepositoryFactory CustomerRoleRepositoryFactory,
            ICustomerViewModelFactory CustomerViewModelFactory)
            : base(navigationService, repositoryFactory, CustomerViewModelFactory)
        {
            using (var CustomerRepository = repositoryFactory.CreateRepository())
            {
                _managers = CustomerRepository.Get().Where(e => e.Role_Role == "Manager").ToList();
            }
            using (var CustomerRoleRepository = CustomerRoleRepositoryFactory.CreateRepository())
            {
                Roles = CustomerRoleRepository.Get().ToList();
            }
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.CustomerAddOrUpdate.Key) return;

            UpdateEntityViewModelFromNavigationParameter();
            UpdateCustomerFromNavigationParameter();
        }

        private readonly IEnumerable<Domain.Customer> _managers;
        public IEnumerable<Domain.Customer> Managers { get { return _managers.Where(m => m.Id != EntityViewModel.Id).ToList(); } }
        public IEnumerable<Domain.CustomerRole> Roles { get; }

        private void UpdateCustomerFromNavigationParameter()
        {

        }

        public override void Save()
        {
            // TODO: Validation
            EntityViewModel.Save();

            //            using (var CustomerQuestionRepository = _CustomerQuestionRepositoryFactory.CreateRepository())
            //            {
            //                foreach (var CustomerQuestion in EntityViewModel.UpdatedEntity.Questions)
            //                    CustomerQuestionRepository.AddOrUpdate(CustomerQuestion);
            //            }

            NavigationService.GoBack(EntityViewModel);
        }
    }
}
