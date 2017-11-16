using System.Collections.Generic;
using System.Linq;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;

namespace Festispec.ViewModels.Template
{
    public class TemplateViewModel : EntityViewModelBase<ITemplateRepositoryFactory, Domain.Template>
    {
        private readonly ITemplateQuestionViewModelFactory _templateQuestionViewModelFactory;

        private TemplateQuestionViewModel _selectedQuestion;

        public TemplateViewModel(ITemplateRepositoryFactory repositoryFactory,
            ITemplateQuestionViewModelFactory templateQuestionViewModelFactory) : base(repositoryFactory)
        {
            _templateQuestionViewModelFactory = templateQuestionViewModelFactory;
        }

        public TemplateViewModel(ITemplateRepositoryFactory repositoryFactory,
            ITemplateQuestionViewModelFactory templateQuestionViewModelFactory, Domain.Template entity)
            : base(repositoryFactory, entity)
        {
            _templateQuestionViewModelFactory = templateQuestionViewModelFactory;
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

        public ICollection<TemplateQuestionViewModel> Questions
        {
            get
            {
                return
                    Entity.Questions.Select(
                        templateQuestion => _templateQuestionViewModelFactory?.CreateViewModel(templateQuestion))
                        .ToList();
            }
            set
            {
                Entity.Questions = value.Select(templateQuestionViewModel => templateQuestionViewModel.Entity).ToList();
                RaisePropertyChanged();
            }
        }

        public TemplateQuestionViewModel SelectedQuestion
        {
            get { return _selectedQuestion; }
            set
            {
                _selectedQuestion = value;
                RaisePropertyChanged();
            }
        }

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
                Questions = Entity.Questions
            };
        }
    }
}