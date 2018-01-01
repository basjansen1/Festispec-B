using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Address;

namespace Festispec.ViewModels.Employee
{
    public class EmployeeViewModel :
        AddressViewModelBase<IEmployeeRepositoryFactory, IEmployeeRepository, Domain.Employee>
    {
        public EmployeeViewModel(IEmployeeRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
            if (HiredFrom == default(DateTime))
                HiredFrom = new DateTime(1990, 1, 1);
        }

        public EmployeeViewModel(IEmployeeRepositoryFactory repositoryFactory, Domain.Employee entity)
            : base(repositoryFactory, entity)
        {
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

        public string Telephone
        {
            get { return Entity.Telephone; }
            set
            {
                Entity.Telephone = value;
                RaisePropertyChanged();
            }
        }

        public string Role_Role
        {
            get { return Entity.Role_Role; }
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

        public int? Manager_Id
        {
            get { return Entity.Manager_Id; }
            set
            {
                Entity.Manager_Id = value;
                RaisePropertyChanged();
            }
        }

        public override bool Save()
        {
            try
            {
                Domain.Employee updated;
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
            }
            catch (DbEntityValidationException ex)
            {
                var ErrorList = new List<string>();
                foreach (var eve in ex.EntityValidationErrors)
                foreach (var ve in eve.ValidationErrors)
                    ErrorList.Add(ve.PropertyName);
                var joined = string.Join(",", ErrorList.Select(x => x));
                MessageBox.Show("Veld(en) niet (correct) ingevuld: " + joined);
                return false;
            }

            return true;
        }

        public override void MapValues(Domain.Employee @from, Domain.Employee to)
        {
            // Call map values on parent model
            MapValues(from, to);

            // Map values
            to.Employees = from.Employees;
            to.HiredFrom = from.HiredFrom;
            to.HiredTo = from.HiredTo;
            to.Manager = from.Manager;
            to.Manager_Id = from.Manager_Id;
            to.Password = from.Password;
            to.Role = from.Role;
            to.Role_Role = from.Role_Role;
            to.Username = from.Username;
        }
    }
}