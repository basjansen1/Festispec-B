using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festispec.ViewModels.RequestProcessing
{
    public class ProcessInspectionVM // this VM is intented for approving or rejecting an inspection request
    {
        // getters and setters
        public InspectionVM InspectionVM { get; set; }

        // commands
        public ICommand ApproveInspectionCommand { get; set; }
        public ICommand RejectInspectionCommand { get; set; }

        // fields
        private InspectionListVM _inspectionList;
        private IRepository<Inspection> _inspectionRepository;

        // constructor
        public ProcessInspectionVM(InspectionListVM InspectionList)
        {
            _inspectionList = InspectionList;
            _inspectionRepository = _inspectionList.InspectionRepositoryFactory.CreateRepository();
            this.InspectionVM = InspectionVM;
        }

        // methods
        public void ApproveInspection()
        {
            using (_inspectionRepository)
            {
                var status = new InspectionStatus();
                status.Status = "Approved";

                InspectionVM.toModel().Status = status;
                _inspectionRepository.AddOrUpdate(InspectionVM.toModel());
            }
        }

        public void RejectInspection()
        {
            using (_inspectionRepository)
            {
                var status = new InspectionStatus();
                status.Status = "Rejected";

                InspectionVM.toModel().Status = status;
                _inspectionRepository.AddOrUpdate(InspectionVM.toModel());
            }
        }
    }
}
