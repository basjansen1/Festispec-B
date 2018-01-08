using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.ViewModels.Planning
{
    public class
        PlanningViewModel : EntityViewModelBase<IPlanningRepositoryFactory, IPlanningRepository, Domain.Planning>
    {
        public PlanningViewModel(IPlanningRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
        }

        public PlanningViewModel(IPlanningRepositoryFactory repositoryFactory, Domain.Planning entity) : base(
            repositoryFactory, entity)
        {
        }

        public int InspectionId
        {
            get { return Entity.Inspection_Id; }
            set
            {
                Entity.Inspection_Id = value;
                RaisePropertyChanged();
            }
        }

        public int InspectorId
        {
            get { return Entity.Inspector_Id; }
            set
            {
                Entity.Inspector_Id = value;
                RaisePropertyChanged();
            }
        }

        public DateTime Date
        {
            get { return Entity.Date; }
            set
            {
                Entity.Date = value;
                RaisePropertyChanged();
            }
        }

        public TimeSpan TimeFrom
        {
            get { return Entity.TimeFrom; }
            set
            {
                Entity.TimeFrom = value;
                RaisePropertyChanged();
            }
        }

        public TimeSpan TimeTo
        {
            get { return Entity.TimeTo; }
            set
            {
                Entity.TimeTo = value;
                RaisePropertyChanged();
            }
        }

        public TimeSpan? Hours
        {
            get { return Entity.Hours; }
            set
            {
                Entity.Hours = value;
                RaisePropertyChanged();
            }
        }

        public virtual Domain.Inspection Inspection
        {
            get { return Entity.Inspection; }
            set
            {
                Entity.Inspection = value;

                // Update inspector Id value
                InspectionId = value?.Id ?? 0;

                RaisePropertyChanged();
            }
        }

        public virtual Domain.Inspector Inspector
        {
            get { return Entity.Inspector; }
            set
            {
                Entity.Inspector = value;

                // Update inspector Id value
                InspectorId = value?.Id ?? 0;

                RaisePropertyChanged();
            }
        }

//        public virtual ICollection<InspectionQuestion> Questions
//        {
//            get { return Entity.Questions; }
//            set
//            {
//                Entity.Questions = value;
//                RaisePropertyChanged();
//            }
//        }

        public override bool Save()
        {
            if (TimeFrom >= TimeTo)
            {
                MessageBox.Show("Tijd tot moet later zijn dan tijd van.");

                return false;
            }

            try
            {
                Domain.Planning updated;
                using (var planningRepository = RepositoryFactory.CreateRepository())
                {
                    updated = Entity.IsAdded
                        ? planningRepository.Add(Entity)
                        : planningRepository.Update(Entity, Entity.Inspection_Id, Entity.Inspector_Id, Entity.Date);
                }
                
                // First we map the updated values to the entity
                MapValues(updated, Entity);
                // Then we overwrite the original values with the new entity values
                MapValuesToOriginal();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                var errorList = ex.EntityValidationErrors.SelectMany(eve => eve.ValidationErrors,
                    (eve, ve) => ve.PropertyName).ToList();
                var joined = string.Join(", ", errorList.Select(x => x));
                MessageBox.Show("Veld(en) niet (correct) ingevuld: " + joined);
                return false;
            }
            return true;
        }

        public override void MapValues(Domain.Planning @from, Domain.Planning to)
        {
            // Map values
            to.Date = from.Date;
            to.Hours = from.Hours;
            to.InspectionQuestionAnswer = from.InspectionQuestionAnswer;
            to.Inspection = from.Inspection;
            to.Inspection_Id = from.Inspection_Id;
            to.Inspector = from.Inspector;
            to.Inspector_Id = from.Inspector_Id;
            to.IsAdded = from.IsAdded;
            to.TimeFrom = from.TimeFrom;
            to.TimeTo = from.TimeTo;
        }
    }
}