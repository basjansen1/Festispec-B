using System.Data.Entity;
using Festispec.Domain.Repository.Interface;
using System.Linq;

namespace Festispec.Domain.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public override IQueryable<Customer> Get()
        {
            return base.Get();
        }

        public override Customer Add(Customer entity)
        {
            entity = CleanRelations(entity);

            return base.Add(entity);
        }

        public override Customer Update(Customer updated, params object[] keyValues)
        {
            updated = CleanRelations(updated);

            return base.Update(updated, keyValues);
        }

        private Customer CleanRelations(Customer entity)
        {
          return entity;
        }
    }
}