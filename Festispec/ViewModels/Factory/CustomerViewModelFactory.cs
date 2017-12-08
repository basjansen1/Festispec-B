using Festispec.Domain.Repository.Factory;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Customer;
using Festispec.ViewModels.CustomerCRUD;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Template;

namespace Festispec.ViewModels.Factory
{
    public class CustomerViewModelFactory :  ICustomerViewModelFactory
    {
        private readonly ICustomerRepositoryFactory _customerRepositoryFactory;
        public CustomerViewModelFactory(ICustomerRepositoryFactory CustomerRepositoryFactory)
        {
            _customerRepositoryFactory = CustomerRepositoryFactory;
        }

        public CustomerViewModel CreateViewModel()
        {
            return new CustomerViewModel(_customerRepositoryFactory);
        }

        public CustomerViewModel CreateViewModel(Domain.Customer entity)
        {
            return new CustomerViewModel(_customerRepositoryFactory, entity);
        }
    }
}