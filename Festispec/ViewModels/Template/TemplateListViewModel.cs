using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;

namespace Festispec.ViewModels.Template
{
    public class TemplateListViewModel : ViewModelBase
    {
        private readonly ITemplateRepositoryFactory _templateRepositoryFactory;
        private readonly ITemplateViewModelFactory _templateViewModelFactory;

        public TemplateListViewModel(ITemplateRepositoryFactory templateRepositoryFactory,
            ITemplateViewModelFactory templateViewModelFactory)
        {
            _templateRepositoryFactory = templateRepositoryFactory;
            _templateViewModelFactory = templateViewModelFactory;

            LoadTemplates();
        }

        public ObservableCollection<TemplateViewModel> Templates { get; private set; }

        public TemplateViewModel SelectedTemplate { get; set; }

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

    /// <summary>
    ///     Temporary classes
    /// </summary>
    public class Template
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    #region ViewModelFactories

    public interface IViewModelFactory<out TViewModel, in TEntity> where TViewModel : ViewModelBase
        where TEntity : class
    {
        TViewModel CreateViewModel();
        TViewModel CreateViewModel(TEntity template);
    }

    public interface ITemplateViewModelFactory : IViewModelFactory<TemplateViewModel, Template>
    {
    }

    public class TemplateViewModelFactory : ITemplateViewModelFactory
    {
        private readonly ITemplateRepositoryFactory _templateRepositoryFactory;

        public TemplateViewModelFactory(ITemplateRepositoryFactory templateRepositoryFactory)
        {
            _templateRepositoryFactory = templateRepositoryFactory;
        }

        public TemplateViewModel CreateViewModel()
        {
            return new TemplateViewModel(_templateRepositoryFactory);
        }

        public TemplateViewModel CreateViewModel(Template template)
        {
            return new TemplateViewModel(_templateRepositoryFactory, template);
        }
    }

    #endregion

    #region RepositoryFactory

    public interface IRepositoryFactory<out TRepository>
    {
        TRepository CreateRepository();
    }

    public interface ITemplateRepositoryFactory : IRepositoryFactory<ITemplateRepository>
    {
    }

    public class TemplateRepositoryFactory : ITemplateRepositoryFactory
    {
        public ITemplateRepository CreateRepository()
        {
            return new TemplateRepository();
        }
    }

    #endregion

    #region Repository

    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Get();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity updated, int key);
    }

    public interface ITemplateRepository : IRepository<Template>, IDisposable
    {
    }

    public class TemplateRepository : ITemplateRepository
    {
        private readonly List<Template> _templates = new List<Template>
        {
            new Template {Id = 1, Name = "Template 1"},
            new Template {Id = 2, Name = "Template 2"},
            new Template {Id = 3, Name = "Template 3"},
            new Template {Id = 4, Name = "Template 4"},
            new Template {Id = 5, Name = "Template 5"},
            new Template {Id = 6, Name = "Template 6"},
            new Template {Id = 7, Name = "Template 7"},
            new Template {Id = 8, Name = "Template 8"},
            new Template {Id = 9, Name = "Template 9"},
            new Template {Id = 10, Name = "Template 10"}
        };

        public IQueryable<Template> Get()
        {
            return new EnumerableQuery<Template>(_templates);
        }

        public Template Add(Template entity)
        {
            _templates.Add(entity);
            return entity;
        }

        public Template Update(Template updated, int id)
        {
            if (updated == null) throw new ArgumentNullException(nameof(updated));
            if (id == 0) throw new ArgumentNullException(nameof(id));

            var existingIndex = _templates.FindIndex(template => template.Id == id);
            _templates.RemoveAt(existingIndex);
            _templates.Insert(existingIndex, updated);

            return updated;
        }

        public void Dispose()
        {
        }
    }

    #endregion
}