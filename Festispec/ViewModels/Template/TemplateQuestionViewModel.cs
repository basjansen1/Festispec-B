using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.ViewModels.Template
{
    public class TemplateQuestionViewModel : EntityViewModelBase<ITemplateQuestionRepositoryFactory, TemplateQuestion>
    {
        public TemplateQuestionViewModel(ITemplateQuestionRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
        }

        public TemplateQuestionViewModel(ITemplateQuestionRepositoryFactory repositoryFactory, TemplateQuestion entity)
            : base(repositoryFactory, entity)
        {
        }

        public int Id => Entity.Id;


        public string Name
        {
            get { return Entity.Name; }
            set
            {
                Entity.Name = value;
                RaisePropertyChanged();
            }
        }


        public string Description
        {
            get { return Entity.Description; }
            set
            {
                Entity.Description = value;
                RaisePropertyChanged();
            }
        }

        public Domain.Template Template
        {
            get { return Entity.Template; }
            set
            {
                Entity.Template = value;
                RaisePropertyChanged();
            }
        }

        public QuestionType QuestionType
        {
            get { return Entity.QuestionType; }
            set
            {
                Entity.QuestionType = value;
                RaisePropertyChanged();
            }
        }

        public override void Save()
        {
            using (var templateQuestionRepository = RepositoryFactory.CreateRepository())
            {
                // TODO: Implement AddOrUpdate in generic repository
                if (Entity.Id == 0)
                {
                    templateQuestionRepository.Add(Entity);
                }
                else
                {
                    templateQuestionRepository.Update(Entity, Entity.Id);
                }
            }
        }

        public override void Delete()
        {
            using (var templateQuestionRepository = RepositoryFactory.CreateRepository())
            {
                templateQuestionRepository.Delete(Entity);
            }
        }

        public override TemplateQuestion Copy()
        {
            return new TemplateQuestion
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Template = Template,
                QuestionType = QuestionType
            };
        }
    }
}