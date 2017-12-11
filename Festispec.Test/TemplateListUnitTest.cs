using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.State;
using Festispec.Test.DummyRepository;
using Festispec.ViewModels.Factory;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Template;
using Moq;
using Xunit;

namespace Festispec.Test
{
    public class TemplateListUnitTest
    {
        private static TemplateListViewModel CreateTemplateListViewModelWithDummyRepository()
        {
            var state = CreateDummyState();
            var navigationService = CreateDummyNavigationService(state);
            var templateRepositoryFactory = CreateDummyTemplateRepositoryFactory();
            var templateQuestionRepositoryFactory = CreateDummyTemplateQuestionRepositoryFactory();
            var templateQuestionViewModelFactory =
                CreateDummyTemplateQuestionViewModelFactory(templateQuestionRepositoryFactory);
            var templateViewModelFactory = CreateTemplateViewModelFactory(templateRepositoryFactory,
                templateQuestionViewModelFactory);

            return new TemplateListViewModel(navigationService, templateRepositoryFactory, templateViewModelFactory);
        }

        private static IState CreateDummyState()
        {
            return new State.State();
        }

        private static INavigationService CreateDummyNavigationService(IState state)
        {
            return new NavigationService.NavigationService(state);
        }

        private static ITemplateRepositoryFactory CreateDummyTemplateRepositoryFactory()
        {
            var templateRepositoryFactoryMock = new Mock<ITemplateRepositoryFactory>();

            var dummyTemplateRepository = new DummyTemplateRepository();
            templateRepositoryFactoryMock.Setup(factory => factory.CreateRepository()).Returns(dummyTemplateRepository);

            return templateRepositoryFactoryMock.Object;
        }

        private static ITemplateQuestionRepositoryFactory CreateDummyTemplateQuestionRepositoryFactory()
        {
            var templateQuestionRepositoryFactoryMock = new Mock<ITemplateQuestionRepositoryFactory>();

            var dummyTemplateQuestionRepository = new DummyTemplateQuestionRepository();
            templateQuestionRepositoryFactoryMock.Setup(factory => factory.CreateRepository())
                .Returns(dummyTemplateQuestionRepository);

            return templateQuestionRepositoryFactoryMock.Object;
        }

        private static ITemplateQuestionViewModelFactory CreateDummyTemplateQuestionViewModelFactory(
            ITemplateQuestionRepositoryFactory templateQuestionRepositoryFactory)
        {
            return new TemplateQuestionViewModelFactory(templateQuestionRepositoryFactory);
        }

        private static ITemplateViewModelFactory CreateTemplateViewModelFactory(
            ITemplateRepositoryFactory templateRepositoryFactory,
            ITemplateQuestionViewModelFactory templateQuestionViewModelFactory)
        {
            return new TemplateViewModelFactory(templateRepositoryFactory, templateQuestionViewModelFactory);
        }

        [Fact]
        public void TemplateListDefaultTest()
        {
            // 1. Arrange
            var templateListViewModel = CreateTemplateListViewModelWithDummyRepository();

            // 2. Act
            templateListViewModel.LoadTemplates();

            // 3. Assert
            Assert.Equal(3, templateListViewModel.Templates.Count);
        }

        [Fact]
        public void TemplateListFilteredTest()
        {
            // 1. Arrange
            var templateListViewModel = CreateTemplateListViewModelWithDummyRepository();
            var expectedTemplate = new Template
            {
                Id = 3,
                Name = "Eet Festival",
                Description = "Deze template is bedoeld voor eetfestivals"
            };

            // 2. Act
            templateListViewModel.SearchName = "Eet";
            templateListViewModel.LoadTemplates();

            // 3. Assert
            Assert.Single(templateListViewModel.Templates);
            Assert.Collection(templateListViewModel.Templates, model => Assert.Equal(expectedTemplate.Id, model.Id));
            Assert.Collection(templateListViewModel.Templates, model => Assert.Equal(expectedTemplate.Name, model.Name));
            Assert.Collection(templateListViewModel.Templates,
                model => Assert.Equal(expectedTemplate.Description, model.Description));
        }
    }
}