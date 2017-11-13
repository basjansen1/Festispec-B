using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class TemplateQuestionRepositoryFactory : RepositoryFactoryBase<TemplateQuestion>, ITemplateQuestionRepositoryFactory
    {
        public override IRepository<TemplateQuestion> CreateRepository()
        {
            return new TemplateQuestionRepository(GetDbContext());
        }
    }
}