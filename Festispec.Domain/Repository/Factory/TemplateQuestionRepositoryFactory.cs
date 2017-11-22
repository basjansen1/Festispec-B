using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class TemplateQuestionRepositoryFactory : RepositoryFactoryBase<ITemplateQuestionRepository, TemplateQuestion>, ITemplateQuestionRepositoryFactory
    {
        public override ITemplateQuestionRepository CreateRepository()
        {
            return new TemplateQuestionRepository(GetDbContext());
        }
    }
}