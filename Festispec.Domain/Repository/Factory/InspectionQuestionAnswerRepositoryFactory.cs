using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class InspectionQuestionAnswerRepositoryFactory : RepositoryFactoryBase<IInspectionQuestionAnswerRepository, InspectionQuestionAnswer>, IInspectionQuestionAnswerRepositoryFactory
    {
        public InspectionQuestionAnswerRepositoryFactory(bool isOnline) : base(isOnline)
        {
        }

        public override IInspectionQuestionAnswerRepository CreateRepository()
        {
            return new InspectionQuestionAnswerRepository(GetDbContext());
        }
    }
}