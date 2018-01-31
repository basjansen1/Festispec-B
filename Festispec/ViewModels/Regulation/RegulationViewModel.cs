using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.ViewModels.Regulation
{
    public class RegulationViewModel : EntityViewModelBase<IRegulationRepositoryFactory, IRegulationRepository, Domain.Regulation>
    {
        public RegulationViewModel(IRegulationRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {

        }

        public RegulationViewModel(IRegulationRepositoryFactory repositoryFactory, Domain.Regulation entity)
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

        public string Municipality
        {
            get { return Entity.Municipality; }
            set
            {
                Entity.Municipality = value;
                RaisePropertyChanged();
            }
        }

        public override bool Save()
        {
            try
            {
                Domain.Regulation updated;
                using (var RegulationsRepository = RepositoryFactory.CreateRepository())
                {
                    updated = Id == 0
                        ? RegulationsRepository.Add(Entity)
                        : RegulationsRepository.Update(Entity, Id);
                }

                // First we map the updated values to the entity
                MapValues(updated, Entity);
                // Then we overwrite the original values with the new entity values
                MapValuesToOriginal();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                List<string> ErrorList = new List<string>();
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        ErrorList.Add(ve.PropertyName);
                    }
                }
                string joined = string.Join(",", ErrorList.Select(x => x));
                MessageBox.Show("Veld(en) niet (correct) ingevuld: " + joined);
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Er is iets fout gegaan. Controleer of alle velden correct zijn ingevuld.");
                return false;
            }

            return true;
        }

        public override void MapValues(Domain.Regulation @from, Domain.Regulation to)
        {
            // Map values
            to.Id = from.Id;
            to.Description = from.Description;
            to.Municipality = from.Municipality;
            to.Name = from.Name;
        }
    }
}


