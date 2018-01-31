using System;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Inspector;

namespace Festispec.ViewModels.Factory
{
    public class InspectionQuestionAnswerViewModelFactory : IInspectionQuestionAnswerViewModelFactory
    {
        private readonly IInspectionQuestionAnswerRepositoryFactory _inspectionQuestionRepositoryFactory;
        public InspectionQuestionAnswerViewModelFactory(IInspectionQuestionAnswerRepositoryFactory inspectorScheduleRepositoryFactory)
        {
            _inspectionQuestionRepositoryFactory = inspectorScheduleRepositoryFactory;
        }

        public InspectionQuestionAnswerViewModel CreateViewModel()
        {
            return new InspectionQuestionAnswerViewModel(_inspectionQuestionRepositoryFactory);
        }

        public InspectionQuestionAnswerViewModel CreateViewModel(InspectionQuestionAnswer entity)
        {
            return new InspectionQuestionAnswerViewModel(_inspectionQuestionRepositoryFactory, entity);
        }
    }
}