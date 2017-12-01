﻿using System;
using System.Collections.Generic;
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

        public virtual Inspection Inspection
        {
            get { return Entity.Inspection; }
            set
            {
                Entity.Inspection = value;
                RaisePropertyChanged();
            }
        }

        public virtual Domain.Inspector Inspector
        {
            get { return Entity.Inspector; }
            set
            {
                Entity.Inspector = value;
                RaisePropertyChanged();
            }
        }

        public virtual ICollection<InspectionQuestion> Questions
        {
            get { return Entity.Questions; }
            set
            {
                Entity.Questions = value;
                RaisePropertyChanged();
            }
        }

        public override bool Save()
        {
            throw new NotImplementedException();
        }

        public override Domain.Planning Copy()
        {
            return new Domain.Planning
            {
                Inspection_Id = InspectionId,
                Inspector_Id = InspectorId,
                Date = Date,
                TimeFrom = TimeFrom,
                TimeTo = TimeTo,
                Hours = Hours,
                Inspection = Inspection,
                Inspector = Inspector,
                Questions = Questions
            };
        }
    }
}