using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.ViewModels.Template
{
    public class TemplateQuestionViewModel : EntityViewModelBase<ITemplateQuestionRepositoryFactory, ITemplateQuestionRepository, TemplateQuestion>
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
                Entity.Template_Id = value.Id;
                RaisePropertyChanged();
            }
        }

        public int Template_Id
        {
            get { return Entity.Template_Id; }
            set
            {
                Entity.Template_Id = value;
                RaisePropertyChanged();
            }
        }

        public QuestionType QuestionType
        {
            get { return Entity.QuestionType; }
            set
            {
                Entity.QuestionType = value;
                Entity.QuestionType_Type = value.Type;
                RaisePropertyChanged();
            }
        }

        public string QuestionType_Type
        {
            get { return Entity.QuestionType_Type; }
            set
            {
                Entity.QuestionType_Type = value;
                RaisePropertyChanged();
            }
        }

        public bool Deleted { get; set; } = false;

        public override void Save()
        {
            TemplateQuestion updated;
            using (var templateQuestionRepository = RepositoryFactory.CreateRepository())
            {
                updated = UpdatedEntity.Id == 0
                    ? templateQuestionRepository.Add(UpdatedEntity)
                    : templateQuestionRepository.Update(UpdatedEntity, UpdatedEntity.Id);
            }

            // Map updated values
            Entity.Id = updated.Id;
            Entity.Name = updated.Name;
            Entity.Description = updated.Description;
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
                Template_Id = Template_Id,
                QuestionType = QuestionType,
                QuestionType_Type = QuestionType_Type
            };
        }
    }
}