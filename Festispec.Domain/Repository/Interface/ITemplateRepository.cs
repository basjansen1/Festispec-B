namespace Festispec.Domain.Repository.Interface
{
    public interface ITemplateRepository : IRepository<Template>
    {
        void AddQuestion(Template template, TemplateQuestion templateQuestion);
    }
}