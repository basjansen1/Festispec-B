using Festispec.Domain;
using Festispec.Domain.Repository.Factory;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.RequestProcessing;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.ViewModels.InspectionProcessing
{
    public class InspectionListFilterVM : ViewModelBase
    {
        // getters and setters

        // commands

        // fields
        private InspectionListVM _inspectionList;
        private IRepository<Inspection> inspectionRepository;

        // constructor
        public InspectionListFilterVM(InspectionListVM InspectionList)
        {
            _inspectionList = InspectionList;
            inspectionRepository = _inspectionList.InspectionRepositoryFactory.CreateRepository();
        }

        // methods
        public void FilterFromByDate(string month)
        {
            this.ClearInspectionList();
            switch (month)
            {
                case "Januari":
                    _inspectionList.InspectionVMList.Add()
                    break;
                case "Februari":
                    break;
                case "Maart":
                    break;
                case "April":
                    break;
                case "Mei":
                    break;
                case "Juni":
                    break;
                case "Juli":
                    break;
                case "Augustus":
                    break;
                case "September":
                    break;
                case "Oktober":
                    break;
                case "November":
                    break;
                case "December":
                    break;
            }
        }

        public void FilterByName(string name)
        {

        }

        public void FilterByStatus(string status)
        {

        }

        public void ClearFilters()
        {

        }

        public void ClearInspectionList()
        {
            _inspectionList.InspectionVMList.Clear();
        }

        // more filter options...
    }
}
