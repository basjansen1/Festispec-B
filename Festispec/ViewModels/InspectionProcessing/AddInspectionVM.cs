using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.InspectionProcessing;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Festispec.ViewModels.RequestProcessing
{
    public class AddInspectionVM : ViewModelBase
    {
        public InspectionListVM InspectionList { get; set; }
        public InspectionVM NewInspection { get; set; }
        public CustomerVM NewCustomer { get; set; }
        public List<Customer> CustomerList { get; set; }

        public ICommand AddInspectionCommand { get; set; }

        public AddInspectionVM(InspectionListVM inspectionList, ICustomerRepositoryFactory customerRepositoryFactory)
        {
            InspectionList = inspectionList;
            NewInspection = new InspectionVM();
            NewInspection.StartDate = DateTime.Now;
            NewInspection.EndDate = DateTime.Now;
            NewInspection.Status = "Pending";
            NewInspection.CustomerId = 11;

            NewInspection.Location = DbGeography.PointFromText("POINT(50 5)", 4326);
            CustomerList = new List<Customer>();
            AddInspectionCommand = new RelayCommand(AddInspection);

            using(var customerRepository = customerRepositoryFactory.CreateRepository())
            {
                customerRepository.Get().ToList().ForEach(c => CustomerList.Add(c));
            }
        }

        public bool CanAddInspection()
        {
            if (NewInspection.Name != null && NewInspection.StartDate != null
                && NewInspection.EndDate != null && NewInspection.Website != null
                && NewInspection.Status != null && NewInspection.Street != null
                && NewInspection.HouseNumber != null && NewInspection.PostalCode != null
                && NewInspection.Country != null && NewInspection.City != null
                && NewInspection.Municipality != null
               // && NewInspection.Location != null
                //&& NewCustomer.City != null && NewCustomer.Country != null && NewCustomer.Email != null 
                //&& NewCustomer.FirstName != null && NewCustomer.LastName != null
                //&& NewCustomer.PostalCode != null && NewCustomer.Street!= null
                //&& NewCustomer.Telephone != null
                )
                return true;

            return false;
        }

        public void AddInspection()
        {
            if (CanAddInspection())
            {
                try
                {

                    using (var inspectionRepository = InspectionList.InspectionRepositoryFactory.CreateRepository())
                    {
                        inspectionRepository.Add(NewInspection.toModel());
                    }

                    InspectionList.InspectionVMList.Add(NewInspection);
                    InspectionList.HideAddInspectionWindow();
                }
                catch (DbEntityValidationException ex)
                {
                    MessageBox.Show("Er is iets fout gegaan met het toevoegen van een inspectie!");
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
                MessageBox.Show("Dit werkt!");

                return;
            }

            MessageBox.Show("Niet alle verplichte velden zijn ingevoerd");
        }
    }
}
