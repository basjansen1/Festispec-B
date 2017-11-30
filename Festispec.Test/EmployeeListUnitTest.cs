using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.State;
using Festispec.Test.DummyRepository;
using Festispec.ViewModels.Factory;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Employee;
using Moq;
using Xunit;

namespace Festispec.Test
{
    public class EmployeeListUnitTest
    {
        private static EmployeeListViewModel CreateEmployeeListViewModelWithDummyRepository()
        {
            var state = CreateDummyState();
            var navigationService = CreateDummyNavigationService(state);
            var employeeRepositoryFactory = CreateDummyEmployeeRepositoryFactory();
            var employeeViewModelFactory = CreateEmployeeViewModelFactory(employeeRepositoryFactory);

            return new EmployeeListViewModel(navigationService, employeeRepositoryFactory, employeeViewModelFactory);
        }

        private static IState CreateDummyState()
        {
            return new State.State();
        }

        private static INavigationService CreateDummyNavigationService(IState state)
        {
            return new NavigationService.NavigationService(state);
        }

        private static IEmployeeRepositoryFactory CreateDummyEmployeeRepositoryFactory()
        {
            var employeeRepositoryFactoryMock = new Mock<IEmployeeRepositoryFactory>();

            var dummyEmployeeRepository = new DummyEmployeeRepository();
            employeeRepositoryFactoryMock.Setup(factory => factory.CreateRepository()).Returns(dummyEmployeeRepository);

            return employeeRepositoryFactoryMock.Object;
        }

        private static IEmployeeViewModelFactory CreateEmployeeViewModelFactory(
            IEmployeeRepositoryFactory employeeRepositoryFactory)
        {
            return new EmployeeViewModelFactory(employeeRepositoryFactory);
        }

        [Fact]
        public void EmployeeListDefaultTest()
        {
            // 1. Arrange
            var employeeListViewModel = CreateEmployeeListViewModelWithDummyRepository();

            // 2. Act
            employeeListViewModel.LoadEmployees();

            // 3. Assert
            Assert.Equal(3, employeeListViewModel.Employees.Count);
        }

        [Fact]
        public void EmployeeListFilteredTest()
        {
            // 1. Arrange
            var employeeListViewModel = CreateEmployeeListViewModelWithDummyRepository();
            var expectedEmployee = new Employee {Id = 3, Username = "David", FirstName = "David"};

            // 2. Act
            employeeListViewModel.SearchUsername = "David";
            employeeListViewModel.LoadEmployees();

            // 3. Assert
            Assert.Single(employeeListViewModel.Employees);
            Assert.Collection(employeeListViewModel.Employees, model => Assert.Equal(expectedEmployee.Id, model.Id));
            Assert.Collection(employeeListViewModel.Employees, model => Assert.Equal(expectedEmployee.Username, model.Username));
            Assert.Collection(employeeListViewModel.Employees,
                model => Assert.Equal(expectedEmployee.FirstName, model.FirstName));
        }
    }
}