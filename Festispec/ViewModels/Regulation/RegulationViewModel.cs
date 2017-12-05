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

            using (var RegulationsRepository = RepositoryFactory.CreateRepository())
            {
                try
                {
                    var updated = UpdatedEntity.Id == 0
                        ? RegulationsRepository.Add(UpdatedEntity)
                        : RegulationsRepository.Update(UpdatedEntity, UpdatedEntity.Id);
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
            }
            return true;
        }

        public override bool Delete()
        {
            using (var RegulationsRepository = RepositoryFactory.CreateRepository())
            {
                return RegulationsRepository.Delete(Entity) != 0;
            }
        }

        public override Domain.Regulation Copy()
        {
            return new Domain.Regulation
            {
                Id = Id,
                Description = Description,
                Municipality = Municipality,
                Name = Name
            };
        }
    }
}


