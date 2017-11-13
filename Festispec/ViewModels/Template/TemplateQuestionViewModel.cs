using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.ViewModels.Template
{
    public class TemplateQuestionViewModel : EntityViewModelBase<ITemplateQuestionRepositoryFactory, Domain.TemplateQuestion>
    {
        public TemplateQuestionViewModel(ITemplateQuestionRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
        }

        public TemplateQuestionViewModel(ITemplateQuestionRepositoryFactory repositoryFactory, Domain.TemplateQuestion entity)
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

        public override void Save()
        {
            using (var templateRepository = RepositoryFactory.CreateRepository())
            {
                // TODO: Implement AddOrUpdate in generic repository
                if (Entity.Id == 0)
                {
                    templateRepository.Add(Entity);
                }
                else
                {
                    templateRepository.Update(Entity, Entity.Id);
                }
            }
        }

        public override Domain.TemplateQuestion Copy()
        {
            return new Domain.TemplateQuestion
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Template = Template,
            };
        }
    }
}