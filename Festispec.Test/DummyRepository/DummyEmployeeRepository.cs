using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Festispec.Domain;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Test.DummyRepository
{
    public class DummyEmployeeRepository : IEmployeeRepository
    {
        private readonly ICollection<Employee> _employees = new List<Employee>
        {
            new Employee {Id = 1, Username = "Minke", FirstName = "Minke", Email = "Minke@festispec.nl", Role_Role = "Manager"},
            new Employee {Id = 2, Username = "Lucinde", FirstName = "Lucinde", Email = "Lucinde@festispec.nl", Role_Role = "Medewerker"},
            new Employee {Id = 3, Username = "David", FirstName = "David", Email = "David@festispec.nl", Role_Role = "Medewerker"},
            new Employee {Id = 4, Username = "Pieter", FirstName = "Pieter", Email = "Pieter@festispec.nl", Role_Role = "Inspecteur"}
        };

        public void Dispose()
        {
            // Do nothing because we want to persist the dummy data
        }

        public IQueryable<Employee> Get()
        {
            return new EnumerableQuery<Employee>(_employees);
        }

        public Employee Get(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Employee Find(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> FindAsync(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<Employee> FindAll(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Employee>> FindAllAsync(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Employee Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> AddAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee updated, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateAsync(Employee updated, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Employee AddOrUpdate(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> AddOrUpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public int Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
    }
}