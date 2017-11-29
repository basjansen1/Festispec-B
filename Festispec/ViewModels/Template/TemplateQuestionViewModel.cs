using System.Linq;
using System.Windows;
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

        public bool IsDeleted
        {
            get { return Entity.IsDeleted; }
            set
            {
                Entity.IsDeleted = value;
                RaisePropertyChanged();
            }
        }

        public override bool Save()
        {
            try
            {
                if (IsDeleted)
                {
                    return Id == 0 || Delete();
                }

                TemplateQuestion updated;
                using (var templateQuestionRepository = RepositoryFactory.CreateRepository())
                {
                    updated = Id == 0
                        ? templateQuestionRepository.Add(Entity)
                        : templateQuestionRepository.Update(Entity, Id);
                }

                // First we map the updated values to the entity
                MapValues(updated, Entity);
                // Then we overwrite the original values with the new entity values
                MapValuesToOriginal();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                var errorList = (from eve in ex.EntityValidationErrors from ve in eve.ValidationErrors select ve.PropertyName).ToList();
                var joined = string.Join(",", errorList.Select(x => x));
                MessageBox.Show("Veld(en) niet (correct) ingevuld: " + joined);
                return false;
            }

            return true;
        }

        public override bool Delete()
        {
            try
            {
                using (var templateQuestionRepository = RepositoryFactory.CreateRepository())
                {
                    return templateQuestionRepository.Delete(Entity) != 0;
                }
            }
            catch
            {
                MessageBox.Show("Er is iets fout gegaan");
                return false;
            }
        }
    }
}