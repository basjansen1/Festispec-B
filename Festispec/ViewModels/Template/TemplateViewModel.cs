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

        public override Domain.Template Copy()
        {
            return new Domain.Template
            {
                Id = Id,
                Name = Name,
                Description = Description
            };
        }
    }
}