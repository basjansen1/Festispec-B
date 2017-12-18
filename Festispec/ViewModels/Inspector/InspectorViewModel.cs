using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Address;
using System.Collections.Generic;
using Festispec.ViewModels.Factory.Interface;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Festispec.ViewModels.Inspector
{
    public class InspectorViewModel :
        AddressViewModelBase<IInspectorRepositoryFactory, IInspectorRepository, Domain.Inspector>
    {
        private InspectorScheduleViewModel _selectedSchedule;
        public InspectorViewModel(IInspectorRepositoryFactory repositoryFactory, IInspectorScheduleViewModelFactory inspectorScheduleViewModelFactory) : base(repositoryFactory)
        {
            Schedule = new ObservableCollection<InspectorScheduleViewModel>(
                Entity.Schedule.Select(inspectorScheduleViewModelFactory.CreateViewModel));
            Schedule.CollectionChanged += ScheduleOnCollectionChanged;
            if (HiredFrom == default(DateTime))
                HiredFrom = new DateTime(1990, 1, 1);
        }

        public InspectorViewModel(IInspectorRepositoryFactory repositoryFactory,
            IInspectorScheduleViewModelFactory inspectorScheduleViewModelFactory, Domain.Inspector entity)
            : base(repositoryFactory, entity)
        {
            Schedule = new ObservableCollection<InspectorScheduleViewModel>(
                Entity.Schedule.Select(inspectorScheduleViewModelFactory.CreateViewModel));
            Schedule.CollectionChanged += ScheduleOnCollectionChanged;
        }

        public int Id => Entity.Id;

        public ObservableCollection<InspectorScheduleViewModel> Schedule { get; }

        private void ScheduleOnCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            switch (notifyCollectionChangedEventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Entity.Schedule.Add(((InspectorScheduleViewModel)notifyCollectionChangedEventArgs.NewItems[0])
                        .Entity);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Entity.Schedule.Remove(((InspectorScheduleViewModel)notifyCollectionChangedEventArgs.OldItems[0])
                        .Entity);
                    break;
            }
        }

        public InspectorScheduleViewModel SelectedSchedule
        {
            get { return _selectedSchedule; }
            set
            {
                _selectedSchedule = value;
                RaisePropertyChanged();
            }
        }
        public string Username
        {
            get { return Entity.Username; }
            set
            {
                Entity.Username = value;
                RaisePropertyChanged();
            }
        }

        public string Email
        {
            get { return Entity.Email; }
            set
            {
                Entity.Email = value;
                RaisePropertyChanged();
            }
        }

        public string FirstName
        {
            get { return Entity.FirstName; }
            set
            {
                Entity.FirstName = value;
                RaisePropertyChanged();
            }
        }

        public string LastName
        {
            get { return Entity.LastName; }
            set
            {
                Entity.LastName = value;
                RaisePropertyChanged();
            }
        }

        public string IBAN
        {
            get { return Entity.IBAN; }
            set
            {
                Entity.IBAN = value;
                RaisePropertyChanged();
            }
        }

        public Domain.Employee Manager
        {
            get { return Entity.Manager; }
            set
            {
                Entity.Manager = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            get { return Entity.Password; }
            set
            {
                Entity.Password = value;
                RaisePropertyChanged();
            }
        }

        public EmployeeRole Role
        {
            get { return Entity.Role; }
            set
            {
                Entity.Role = value;
                RaisePropertyChanged();
            }
        }

        public string Role_Role
        {
            get { return Entity.Role_Role; }
            set
            {
                Entity.Role_Role = value;
                RaisePropertyChanged();
            }
        }

        public string Telephone
        {
            get { return Entity.Telephone; }
            set
            {
                Entity.Telephone = value;
                RaisePropertyChanged();
            }
        }

        public DateTime HiredFrom
        {
            get { return Entity.HiredFrom; }
            set
            {
                Entity.HiredFrom = value;
                RaisePropertyChanged();
            }
        }

        public DateTime? HiredTo
        {
            get { return Entity.HiredTo; }
            set
            {
                Entity.HiredTo = value;
                RaisePropertyChanged();
            }
        }

        public DateTime? CertificationFrom
        {
            get { return Entity.CertificationFrom; }
            set
            {
                Entity.CertificationFrom = value;
                RaisePropertyChanged();
            }
        }

        public int? Manager_Id
        {
            get { return Entity.Manager_Id; }
            set
            {
                Entity.Manager_Id = value;
                RaisePropertyChanged();
            }
        }

        public DateTime? CertificationTo
        {
            get { return Entity.CertificationTo; }
            set
            {
                Entity.CertificationTo = value;
                RaisePropertyChanged();
            }
        }

        public override bool Save()
        {
            try
            {
                Domain.Inspector updated;
                var scheduleToUpdate = Schedule;
                using (var InspectorRepository = RepositoryFactory.CreateRepository())
                {
                    updated = Id == 0
                        ? InspectorRepository.Add(Entity)
                        : InspectorRepository.Update(Entity, Id);
                }

                // First we map the updated values to the entity
                MapValues(updated, Entity);
                // Then we overwrite the original values with the new entity values
                MapValuesToOriginal();
                foreach (var inspectorScheduleViewModel in scheduleToUpdate)
                {
                    // Manually attach the template by id
                    inspectorScheduleViewModel.Inspector_Id = Entity.Id;
                    inspectorScheduleViewModel.Save();
                }
            }
            catch (DbEntityValidationException ex)
            {
                var ErrorList = (from eve in ex.EntityValidationErrors
                                 from ve in eve.ValidationErrors
                                 select ve.PropertyName).ToList();
                var joined = string.Join(",", ErrorList.Select(x => x));
                MessageBox.Show("Veld(en) niet (correct) ingevuld: " + joined);
                return false;
            }

            return true;
        }

    }
}