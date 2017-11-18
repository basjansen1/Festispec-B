using System.Data.Entity;
using System.Linq;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class TemplateQuestionRepository : RepositoryBase<TemplateQuestion>, ITemplateQuestionRepository
    {
        public TemplateQuestionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<TemplateQuestion> Get()
        {
            return base.Get().Include(templateQuestion => templateQuestion.QuestionType);
        }

        public override TemplateQuestion Add(TemplateQuestion entity)
        {
            if (entity.Template != null)
            {
                // Set foreign key and unset the navigation property
                // This is needed because we are working with disconnected entities.
                entity.Template_Id = entity.Template.Id;
                entity.Template = null;
            }

            if (entity.QuestionType != null)
            {
                // Set foreign key and unset the navigation property
                // This is needed because we are working with disconnected entities.
                entity.QuestionType_Type = entity.QuestionType.Type;
                entity.QuestionType = null;
            }

            return base.Add(entity);
        }
    }
}