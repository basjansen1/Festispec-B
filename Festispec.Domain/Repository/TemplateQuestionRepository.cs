using System.Data.Entity;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class TemplateQuestionRepository : RepositoryBase<TemplateQuestion>, ITemplateQuestionRepository
    {
        public TemplateQuestionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}