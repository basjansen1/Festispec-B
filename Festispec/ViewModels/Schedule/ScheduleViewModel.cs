using System.Collections.Generic;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using System.Data.Entity.Spatial;
using System;
using System.Windows;
using System.Linq;

namespace Festispec.ViewModels.Schedule
{
    public class ScheduleViewModel : EntityViewModelBase<IScheduleRepositoryFactory, IScheduleRepository, Domain.Schedule>
    {
        public ScheduleViewModel(IScheduleRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
        }

        public ScheduleViewModel(IScheduleRepositoryFactory repositoryFactory, Domain.Schedule entity)
            : base(repositoryFactory, entity)
        {
        }

        public int Id => Entity.Id;


        public Domain.Inspector Inspector
        {
            get { return Entity.Inspector; }
            set
            {
                Entity.Inspector = value;
                RaisePropertyChanged();
            }
        }

        public int Inspector_Id
        {
            get { return Entity.Inspector_Id; }
            set
            {
                Entity.Inspector_Id = value;
                RaisePropertyChanged();
            }
        }

        public DateTime NotAvailableFrom
        {
            get { return Entity.NotAvailableFrom; }
            set
            {
                Entity.NotAvailableFrom = value;
                RaisePropertyChanged();
            }
        }
        public DateTime NotAvailableTo
        {
            get { return Entity.NotAvailableTo; }
            set
            {
                Entity.NotAvailableTo = value;
                RaisePropertyChanged();
            }
        }
        public override bool Save()
        {

            using (var ScheduleRepository = RepositoryFactory.CreateRepository())
            {
                try
                {
                    var updated = UpdatedEntity.Id == 0
                        ? ScheduleRepository.Add(UpdatedEntity)
                        : ScheduleRepository.Update(UpdatedEntity, UpdatedEntity.Id);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    var ErrorList = (from eve in ex.EntityValidationErrors from ve in eve.ValidationErrors select ve.PropertyName).ToList();
                    string joined = string.Join(",", ErrorList.Select(x => x));
                    MessageBox.Show("Veld(en) niet (correct) ingevuld: " + joined);
                    return false;
                }
            }
            return true;
        }

        public override bool Delete()
        {
            using (var ScheduleRepository = RepositoryFactory.CreateRepository())
            {
                return ScheduleRepository.Delete(Entity) != 0;
            }
        }

        public override Domain.Schedule Copy()
        {
            return new Domain.Schedule
            {
                Id = Id,
                NotAvailableFrom = NotAvailableFrom,
                NotAvailableTo = NotAvailableTo,
                Inspector_Id = Inspector_Id,
                Inspector = Inspector
            };
        }
    }
}