using System;

namespace Festispec.Domain.Repository.Interface
{
    public interface IInspectionRepository : IRepository<Inspection>
    {
        void AddQuestion(Inspection inspection, Question question);

        void AddOrUpdateQuestionAnswer(int inspectionId, int inspectorId, DateTime date, int questionId, string answer);
    }
}