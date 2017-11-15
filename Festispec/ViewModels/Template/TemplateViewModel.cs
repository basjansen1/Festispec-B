using System.Collections.Generic;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.ViewModels.Template
{
    public class TemplateViewModel : EntityViewModelBase<ITemplateRepositoryFactory, Domain.Template>
    {
        public TemplateViewModel(ITemplateRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
        }

        public TemplateViewModel(ITemplateRepositoryFactory repositoryFactory, Domain.Template entity)
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
                // TODO: Figure out which one works...
                //RaisePropertyChanged();
                //RaisePropertyChanged(null);
                //RaisePropertyChanged("");
                //RaisePropertyChanged(string.Empty);
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

        public ICollection<TemplateQuestion> Questions
        {
            get { return Entity.Questions; }
            set
            {
                Entity.Questions = value;
                RaisePropertyChanged();
            }
        }

        public TemplateQuestionViewModel SelectedQuestion { get; set; }

        public override void Save()
        {
            // Map updated values
//            Entity.Id = UpdatedEntity.Id;
//            Entity.Name = UpdatedEntity.Name;
//            Entity.Description = UpdatedEntity.Description;
//            Entity.Questions = UpdatedEntity.Questions;

            using (var templateRepository = RepositoryFactory.CreateRepository())
            {
                var updated = templateRepository.AddOrUpdate(Entity);
            }
        }

        public override void Delete()
        {
            using (var templateRepository = RepositoryFactory.CreateRepository())
            {
                templateRepository.Delete(Entity);
            }
        }

        public override Domain.Template Copy()
        {
            return new Domain.Template
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Questions = Questions
            };
        }
    }
}