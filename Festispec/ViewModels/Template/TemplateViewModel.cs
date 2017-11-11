using Festispec.ViewModels.Interface;
using GalaSoft.MvvmLight;

namespace Festispec.ViewModels.Template
{
    public class TemplateViewModel : ViewModelBase, IEntityViewModel
    {
        private readonly Template _template;
        private readonly ITemplateRepositoryFactory _templateRepositoryFactory;

        public TemplateViewModel(ITemplateRepositoryFactory templateRepositoryFactory)
        {
            _templateRepositoryFactory = templateRepositoryFactory;
            _template = new Template();
        }

        public TemplateViewModel(ITemplateRepositoryFactory templateRepositoryFactory, Template template)
        {
            _templateRepositoryFactory = templateRepositoryFactory;
            _template = template;
        }

        public int Id => _template.Id;


        public string Name
        {
            get { return _template.Name; }
            set
            {
                _template.Name = value;
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
            get { return _template.Description; }
            set
            {
                _template.Description = value;
                RaisePropertyChanged();
            }
        }

        public void Save()
        {
            using (var templateRepository = _templateRepositoryFactory.CreateRepository())
            {
                // TODO: Implement AddOrUpdate in generic repository
                if (_template.Id == 0)
                {
                    templateRepository.Add(_template);
                }
                else
                {
                    templateRepository.Update(_template, _template.Id);
                }
            }
        }
    }
}