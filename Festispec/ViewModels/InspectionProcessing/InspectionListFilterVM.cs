using Festispec.Domain;
using Festispec.Domain.Repository.Factory;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.RequestProcessing;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festispec.ViewModels.InspectionProcessing
{
    public class InspectionListFilterVM : ViewModelBase
    {
        // getters and setters

        // commands
        public ICommand FilterByStartDateCommand;
        public ICommand FilterByEndDateCommand;

        // fields
        private InspectionListVM _inspectionList;
        private IRepository<Inspection> inspectionRepository;

        // constructor
        public InspectionListFilterVM(InspectionListVM InspectionList)
        {
            _inspectionList = InspectionList;
            inspectionRepository = _inspectionList.InspectionRepositoryFactory.CreateRepository();

            FilterByStartDateCommand = new RelayCommand<int>(FilterByStartDate);
            FilterByEndDateCommand = new RelayCommand<int>(FilterByEndDate);
        }

        // methods
        public void FilterByStartDate(int month)
        {
            this.ClearInspectionList();
            List<Inspection> inspectionlist;

            using(inspectionRepository)
            {
             inspectionlist = inspectionRepository.Get().Where(i => i.Start.Month == month).ToList();
            }

            inspectionlist.ForEach(i => _inspectionList.InspectionVMList.Add(new InspectionVM(i)));
        }

        public void FilterByEndDate(int month)
        {
            this.ClearInspectionList();
            List<Inspection> inspectionlist;

            using (inspectionRepository)
            {
                inspectionlist = inspectionRepository.Get().Where(i => i.End.Month == month).ToList();
            }

            inspectionlist.ForEach(i => _inspectionList.InspectionVMList.Add(new InspectionVM(i)));
        }

        public void FilterByName(string name)
        {
            this.ClearInspectionList();
            List<Inspection> inspectionlist;

            using (inspectionRepository)
            {
                inspectionlist = inspectionRepository.Get().Where(i => i.Name == name).ToList();
            }

            inspectionlist.ForEach(i => _inspectionList.InspectionVMList.Add(new InspectionVM(i)));
        }

        public void ClearFilters()
        {
            this.ClearInspectionList();
            List<Inspection> inspectionlist;

            using (inspectionRepository)
            {
                inspectionlist = inspectionRepository.Get().ToList();
            }

            inspectionlist.ForEach(i => _inspectionList.InspectionVMList.Add(new InspectionVM(i)));
        }

        public void ClearInspectionList()
        {
            _inspectionList.InspectionVMList.Clear();
        }
    }
}
