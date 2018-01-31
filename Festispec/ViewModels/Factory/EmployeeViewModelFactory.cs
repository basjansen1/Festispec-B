using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Employee;

namespace Festispec.ViewModels.Factory
{
    public class EmployeeViewModelFactory : IEmployeeViewModelFactory
    {
        private readonly IEmployeeRepositoryFactory _EmployeeRepositoryFactory;
        public EmployeeViewModelFactory(IEmployeeRepositoryFactory EmployeeRepositoryFactory)
        {
            _EmployeeRepositoryFactory = EmployeeRepositoryFactory;
        }

        public EmployeeViewModel CreateViewModel()
        {
            return new EmployeeViewModel(_EmployeeRepositoryFactory);
        }

        public EmployeeViewModel CreateViewModel(Domain.Employee entity)
        {
            return new EmployeeViewModel(_EmployeeRepositoryFactory, entity);
        }
    }
}