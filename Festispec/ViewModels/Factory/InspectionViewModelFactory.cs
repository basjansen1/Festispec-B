using Festispec.ViewModels.Inspection;
using Festispec.Domain.Repository.Factory.Interface;

namespace Festispec.ViewModels.Factory.Interface
{
    class InspectionViewModelFactory : IInspectionViewModelFactory
    {
        private readonly IInspectionRepositoryFactory _inspectionRepositoryFactory;
        private readonly IQuestionViewModelFactory _questionViewModelFactory;
        public InspectionViewModelFactory(IInspectionRepositoryFactory inspectionRepositoryFactory, IQuestionViewModelFactory questionViewModelFactory)
        {
            _inspectionRepositoryFactory = inspectionRepositoryFactory;
            _questionViewModelFactory = questionViewModelFactory;
        }

        public InspectionVM CreateViewModel()
        {
            return new InspectionVM(_inspectionRepositoryFactory);
        }

        public InspectionVM CreateViewModel(Domain.Inspection entity)
        {
            return new InspectionVM(_inspectionRepositoryFactory, entity);
        }
    }
}
