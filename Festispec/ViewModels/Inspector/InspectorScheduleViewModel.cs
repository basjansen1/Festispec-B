using System.Linq;
using System.Windows;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.ViewModels.Inspector
{
    public class InspectorScheduleViewModel : EntityViewModelBase<IInspectorScheduleRepositoryFactory, IInspectorScheduleRepository, Domain.Schedule>
    {
        public InspectorScheduleViewModel(IInspectorScheduleRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
        }

        public InspectorScheduleViewModel(IInspectorScheduleRepositoryFactory repositoryFactory, Domain.Schedule entity)
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
                Entity.Inspector_Id = value.Id;
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

        public System.DateTime NotAvailableFrom
        {
            get { return Entity.NotAvailableFrom; }
            set
            {
                Entity.NotAvailableFrom = value;
                RaisePropertyChanged();
            }
        }
        public System.DateTime NotAvailableTo
        {
            get { return Entity.NotAvailableTo; }
            set
            {
                Entity.NotAvailableTo = value;
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

                Domain.Schedule updated;
                using (var inspectorScheduleRepository = RepositoryFactory.CreateRepository())
                {
                    updated = Id == 0
                        ? inspectorScheduleRepository.Add(Entity)
                        : inspectorScheduleRepository.Update(Entity, Id);
                }

                // Map updated values
                NotAvailableFrom = NotAvailableFrom;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                var ErrorList = (from eve in ex.EntityValidationErrors from ve in eve.ValidationErrors select ve.PropertyName).ToList();
                string joined = string.Join(",", ErrorList.Select(x => x));
                MessageBox.Show("Veld(en) niet (correct) ingevuld: " + joined);
                return false;
            }

            return true;
        }

        public override bool Delete()
        {
            try
            {
                using (var inspectorScheduleRepository = RepositoryFactory.CreateRepository())
                {
                    return inspectorScheduleRepository.Delete(Entity) != 0;
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