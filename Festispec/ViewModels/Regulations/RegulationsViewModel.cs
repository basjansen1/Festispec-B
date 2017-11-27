using System.Collections.Generic;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using System.Data.Entity.Spatial;
using System;
using System.Windows;
using System.Linq;

namespace Festispec.ViewModels.Regulations
{
    public class RegulationsViewModel : EntityViewModelBase<IRegulationsRepositoryFactory, IRegulationsRepository, Domain.Regulation>
    {
        public RegulationsViewModel(IRegulationsRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
            
        }

        public RegulationsViewModel(IRegulationsRepositoryFactory repositoryFactory, Domain.Regulation entity)
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



        public override Regulation Copy()
        {
            throw new NotImplementedException();
        }

    }
}
