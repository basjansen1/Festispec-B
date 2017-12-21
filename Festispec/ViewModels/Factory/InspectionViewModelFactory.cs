using Festispec.ViewModels.Inspection;
using Festispec.Domain.Repository.Factory.Interface;

namespace Festispec.ViewModels.Factory.Interface
{
    class InspectionViewModelFactory : IInspectionViewModelFactory
    {
        private readonly IInspectionRepositoryFactory _inspectionRepositoryFactory;
        private readonly IQuestionViewModelFactory _questionViewModelFactory;
        private readonly IInspectionQuestionAnswerRepositoryFactory _answerRepositoryFactory;
        public InspectionViewModelFactory(IInspectionRepositoryFactory inspectionRepositoryFactory, IQuestionViewModelFactory questionViewModelFactory, IInspectionQuestionAnswerRepositoryFactory answerRepositoryFactory)
        {
            _inspectionRepositoryFactory = inspectionRepositoryFactory;
            _questionViewModelFactory = questionViewModelFactory;
            _answerRepositoryFactory = answerRepositoryFactory;
        }

        public InspectionVM CreateViewModel()
        {
            return new InspectionVM(_inspectionRepositoryFactory, _questionViewModelFactory, _answerRepositoryFactory);
        }

        public InspectionVM CreateViewModel(Domain.Inspection entity)
        {
            return new InspectionVM(_inspectionRepositoryFactory, _questionViewModelFactory, entity);
        }
    }
}
