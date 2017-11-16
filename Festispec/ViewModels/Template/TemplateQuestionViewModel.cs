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

        public bool Deleted { get; set; } = false;

        public override void Save()
        {
            // Map updated values
//            Entity.Id = UpdatedEntity.Id;
//            Entity.Name = UpdatedEntity.Name;
//            Entity.Description = UpdatedEntity.Description;
//            Entity.QuestionType = UpdatedEntity.QuestionType;
//            Entity.Template = UpdatedEntity.Template;

            using (var templateQuestionRepository = RepositoryFactory.CreateRepository())
            {
                templateQuestionRepository.AddOrUpdate(Entity);
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