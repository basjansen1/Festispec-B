using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels.Template
{
    public class TemplateListViewModel : NavigatableViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ITemplateRepositoryFactory _templateRepositoryFactory;
        private readonly ITemplateViewModelFactory _templateViewModelFactory;

        public TemplateListViewModel(INavigationService navigationService,
            ITemplateRepositoryFactory templateRepositoryFactory,
            ITemplateViewModelFactory templateViewModelFactory) : base(navigationService)
        {
            _navigationService = navigationService;
            _templateRepositoryFactory = templateRepositoryFactory;
            _templateViewModelFactory = templateViewModelFactory;

            RegisterCommands();
            LoadTemplates();

            NavigationService.PropertyChanged += OnNavigationServicePropertyChanged;
        }

        private void OnNavigationServicePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;
            
            if (NavigationService.CurrentPageKey != Routes.Routes.TemplateUpdate.Key &&
                NavigationService.CurrentPageKey != Routes.Routes.TemplateAdd.Key) return;

            UpdateTemplatesFromNavigationParameter();
        }

        private void UpdateTemplatesFromNavigationParameter()
        {
            var templateViewModel = NavigationService.Parameter as TemplateViewModel;
            if (templateViewModel == null) return;

            var existing = Templates.First(template => template.Id == templateViewModel.Id);
            if (existing == null) Templates.Add(templateViewModel);
            else
            {
                var index = Templates.IndexOf(existing);
                Templates.RemoveAt(index);
                Templates.Insert(index, templateViewModel);
            }
        }

        public ICommand NavigateToTemplateAddCommand { get; set; }
        public ICommand NavigateToTemplateUpdateCommand { get; set; }

        public ObservableCollection<TemplateViewModel> Templates { get; private set; }

        public TemplateViewModel SelectedTemplate { get; set; }

        private void RegisterCommands()
        {
            NavigateToTemplateAddCommand = new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.TemplateAdd.Key));
            NavigateToTemplateUpdateCommand = new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.TemplateUpdate.Key, SelectedTemplate), () => SelectedTemplate != null);
        }

        private void LoadTemplates()
        {
            using (var templateRepository = _templateRepositoryFactory.CreateRepository())
            {
                Templates =
                    new ObservableCollection<TemplateViewModel>(
                        templateRepository.Get()
                            .ToList()
                            .Select(template => _templateViewModelFactory.CreateViewModel(template)));
            }
        }
    }

//    #region Temporary classes
//
//    #region Models
//
//    public class Template
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string Description { get; set; }
//    }
//
//    #endregion
//    
//    #region RepositoryFactory
//
//    public interface IRepositoryFactory<out TRepository>
//    {
//        TRepository CreateRepository();
//    }
//
//    public interface ITemplateRepositoryFactory : IRepositoryFactory<ITemplateRepository>
//    {
//    }
//
//    public class TemplateRepositoryFactory : ITemplateRepositoryFactory
//    {
//        public ITemplateRepository CreateRepository()
//        {
//            return new TemplateRepository();
//        }
//    }
//
//    #endregion
//
//    #region Repository
//
//    public interface IRepository<TEntity>
//    {
//        IQueryable<TEntity> Get();
//        TEntity Add(TEntity entity);
//        TEntity Update(TEntity updated, int key);
//    }
//
//    public interface ITemplateRepository : IRepository<Template>, IDisposable
//    {
//    }
//
//    public class TemplateRepository : ITemplateRepository
//    {
//        private readonly List<Template> _templates = new List<Template>
//        {
//            new Template {Id = 1, Name = "Template 1"},
//            new Template {Id = 2, Name = "Template 2"},
//            new Template {Id = 3, Name = "Template 3"},
//            new Template {Id = 4, Name = "Template 4"},
//            new Template {Id = 5, Name = "Template 5"},
//            new Template {Id = 6, Name = "Template 6"},
//            new Template {Id = 7, Name = "Template 7"},
//            new Template {Id = 8, Name = "Template 8"},
//            new Template {Id = 9, Name = "Template 9"},
//            new Template {Id = 10, Name = "Template 10"}
//        };
//
//        public IQueryable<Template> Get()
//        {
//            return new EnumerableQuery<Template>(_templates);
//        }
//
//        public Template Add(Template entity)
//        {
//            _templates.Add(entity);
//            return entity;
//        }
//
//        public Template Update(Template updated, int id)
//        {
//            if (updated == null) throw new ArgumentNullException(nameof(updated));
//            if (id == 0) throw new ArgumentNullException(nameof(id));
//
//            var existingIndex = _templates.FindIndex(template => template.Id == id);
//            _templates.RemoveAt(existingIndex);
//            _templates.Insert(existingIndex, updated);
//
//            return updated;
//        }
//
//        public void Dispose()
//        {
//        }
//    }
//
//    #endregion
//
//    #endregion
}