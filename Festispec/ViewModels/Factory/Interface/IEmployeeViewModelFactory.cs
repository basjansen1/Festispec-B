using Festispec.ViewModels.Interface;
using Festispec.ViewModels.Employee;
using Festispec.ViewModels.Employees;

namespace Festispec.ViewModels.Factory.Interface
{
    public interface IEmployeeViewModelFactory : IViewModelFactory<EmployeeViewModel, Domain.Employee>
    {
    }
}