using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festispec.Domain;
using System.Collections.ObjectModel;

namespace Festispec.ViewModels.Regulation
{
    public class RegulationVM : ViewModelBase
    {
        #region properties

        public string Name
        {
            get
            {
                return _regulation.Name;
            }
            set
            {
                _regulation.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Description
        {
            get
            {
                return _regulation.Description;
            }
            set
            {
                _regulation.Description = value;
                RaisePropertyChanged("Description");
            }
        }

        public string Municipality
        {
            get
            {
                return _regulation.Municipality;
            }
            set
            {
                _regulation.Municipality = value;
                RaisePropertyChanged("Municipality");
            }
        }

        #endregion

        #region fields
        private Festispec.Domain.Regulation _regulation;
        #endregion

        #region constructors and methods

        public RegulationVM()
        {
            _regulation = new Festispec.Domain.Regulation();
        }

        public RegulationVM(Festispec.Domain.Regulation i)
        {
            _regulation = i;
        }

        public Festispec.Domain.Regulation ToModel()
        {
            return _regulation;
        }

        #endregion
    }
}
