using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using System.Collections.ObjectModel;

namespace Festispec.ViewModels.Question
{
    public class QuestionViewModel
        : EntityViewModelBase<IQuestionRepositoryFactory, IQuestionRepository, Domain.Question>
    {
        public QuestionViewModel(IQuestionRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
        }

        public QuestionViewModel(IQuestionRepositoryFactory repositoryFactory, Domain.Question entity)
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

        public ObservableCollection<InspectionQuestionAnswer> Answers { get; }

        public string Description
        {
            get { return Entity.Description; }
            set
            {
                Entity.Description = value;
                RaisePropertyChanged();
            }
        }

        public QuestionType QuestionType
        {
            get { return Entity.QuestionType; }
            set
            {
                Entity.QuestionType = value;
                QuestionType_Type = value?.Type;
                RaisePropertyChanged();
            }
        }

        // ReSharper disable once InconsistentNaming
        public string QuestionType_Type
        {
            get { return Entity.QuestionType_Type; }
            set
            {
                Entity.QuestionType_Type = value;
                RaisePropertyChanged();
            }
        }

        public bool IsDeleted
        {
            get { return Entity.IsDeleted; }
            set
            {
                Entity.IsDeleted = value;
                RaisePropertyChanged();
            }
        }

        public string MetadataParameter1
        {
            get { return Entity.MetadataParameter1; }
            set
            {
                Entity.MetadataParameter1 = value;
                RaisePropertyChanged();
            }
        }

        public string MetadataParameter2
        {
            get { return Entity.MetadataParameter2; }
            set
            {
                Entity.MetadataParameter2 = value;
                RaisePropertyChanged();
            }
        }

        public override bool Save()
        {
            if (QuestionType_Type == "Tabel" && (string.IsNullOrWhiteSpace(MetadataParameter1) || string.IsNullOrWhiteSpace(MetadataParameter2)))
            {
                MessageBox.Show("Vul de kolom namen in van de tabel");
                return false;
            }

            // TODO: Validation

            // Only allow add not update
            if (Entity.Id != 0)
                return true;

            try
            {
                Domain.Question added;
                using (var questionRepository = RepositoryFactory.CreateRepository())
                {
                    added = questionRepository.Add(Entity);
                }

                // First we map the updated values to the entity
                MapValues(added, Entity);
                // Then we overwrite the original values with the new entity values
                MapValuesToOriginal();

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                var errorList = ex.EntityValidationErrors.SelectMany(eve => eve.ValidationErrors,
                    (eve, ve) => ve.PropertyName).ToList();
                var joined = string.Join(", ", errorList.Select(x => x));
                MessageBox.Show("Veld(en) niet (correct) ingevuld: " + joined);
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Er is iets fout gegaan. Controleer of alle velden correct zijn ingevuld.");
                return false;
            }
        }
    }
}