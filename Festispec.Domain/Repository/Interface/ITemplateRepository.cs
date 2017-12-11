namespace Festispec.Domain.Repository.Interface
{
    public interface ITemplateRepository : IRepository<Template>
    {
        void TryAttachQuestion(Template template, Question question);
        void AttachQuestions(Template template, Question question);
        void DetachQuestions(Template template, Question question);
    }
}