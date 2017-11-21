using Festispec.ViewModels.CustomerCRUD;
using Festispec.ViewModels.Interface;
using Festispec.ViewModels.Template;

namespace Festispec.ViewModels.Factory.Interface
{
    public interface ICustomerViewModelFactory : IViewModelFactory<CustomerViewModel, Domain.Customer>
    {
    }
}