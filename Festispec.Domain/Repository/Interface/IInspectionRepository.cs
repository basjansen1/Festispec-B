using System;

namespace Festispec.Domain.Repository.Interface
{
    public interface IInspectionRepository : IRepository<Inspection>
    {
        void AddQuestion(Inspection inspection, Question question);
        void TryAttachQuestion(Inspection inspection, Question question);
        void AttachQuestions(Inspection inspection, Question question);
        void DetachQuestions(Inspection inspection, Question question);
    }
}