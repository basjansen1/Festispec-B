using System.Data.Entity;
using System.Linq;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class TemplateRepository : RepositoryBase<Template>, ITemplateRepository
    {
        public TemplateRepository(DbContext dbContext) : base(dbContext)
        {
        }

        IQueryable<Template> IRepository<Template>.Get()
        {
            return Get().Include(template => template.Questions).AsNoTracking();
        }
    }
}