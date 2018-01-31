using Festispec.Domain;
using Festispec.ViewModels.Question;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using Festispec.ViewModels.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using System.Data.Entity.Validation;
using Festispec.ViewModels.Address;

namespace Festispec.ViewModels.Inspection
{
    public class InspectionVM : AddressViewModelBase<IInspectionRepositoryFactory, IInspectionRepository, Domain.Inspection>, IHasQuestionCollection
    {
        public InspectionVM(IInspectionRepositoryFactory repositoryFactory, IQuestionViewModelFactory questionViewModelFactory, IInspectionQuestionAnswerRepositoryFactory answerRepositoryFactory) : base(repositoryFactory)
        {
            Questions = new ObservableCollection<QuestionViewModel>(
                Entity.InspectionQuestion.Select(question =>
                    questionViewModelFactory.CreateViewModel(question.Question)));
            using (var answerRepository = answerRepositoryFactory.CreateRepository())
            {
                Answers = new ObservableCollection<InspectionQuestionAnswer>(answerRepository.Get().ToList());
            }
        }

        public InspectionVM(IInspectionRepositoryFactory repositoryFactory, IQuestionViewModelFactory questionViewModelFactory, Domain.Inspection entity )
            : base(repositoryFactory, entity)
        {
            Questions = new ObservableCollection<QuestionViewModel>(
                 Entity.InspectionQuestion.Select(question =>
                     questionViewModelFactory.CreateViewModel(question.Question)));
        }

        public ObservableCollection<InspectionQuestionAnswer> Answers { get; }


        // getters and setters
        public string Name
        {
            get
            {
                return Entity.Name;
            }
            set
            {
                Entity.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Website
        {
            get
            {
                return Entity.Website;
            }
            set
            {
                Entity.Website = value;
                RaisePropertyChanged("Website");
            }
        }

        public DateTime StartDate
        {
            get
            {
                return Entity.Start;
            }
            set
            {
                Entity.Start = value;
                RaisePropertyChanged("StartDate");
            }
        }

        public DateTime EndDate
        {
            get
            {
                return Entity.End;
            }
            set
            {
                Entity.End = value;
                RaisePropertyChanged("EndDate");
            }
        }
        public string City
        {
            get
            {
                return Entity.City;
            }
            set
            {
                Entity.City = value;
                RaisePropertyChanged("City");
            }
        }
        public string Street
        {
            get
            {
                return Entity.Street;
            }
            set
            {
                Entity.Street = value;
                RaisePropertyChanged("Street");
            }
        }

        public string PostalCode
        {
            get
            {
                return Entity.PostalCode;
            }
            set
            {
                Entity.PostalCode = value;
                RaisePropertyChanged("PostalCode");
            }
        }

        public string HouseNumber
        {
            get
            {
                return Entity.HouseNumber;
            }
            set
            {
                Entity.HouseNumber = value;
                RaisePropertyChanged("HouseNumber");
            }
        }

        public string Country
        {
            get
            {
                return Entity.Country;
            }
            set
            {
                Entity.Country = value;
                RaisePropertyChanged("Country");
            }
        }
        public string Status
        {
            get
            {
                return Entity.Status_Status;
            }
            set
            {
                Entity.Status_Status = value;
                RaisePropertyChanged("Status");
            }
        }

        public int CustomerId
        {
            get
            {
                return Entity.Customer_Id;
            }
            set
            {
                Entity.Customer_Id = value;
            }
        }

        public double Lat
        {
            get
            {
                return Entity.Lat;
            }
            set
            {
                Entity.Lat = value;
                RaisePropertyChanged();
            }
        }

        public double Long
        {
            get
            {
                return Entity.Long;
            }
            set
            {
                Entity.Long = value;
                RaisePropertyChanged();
            }
        }

        public DbGeography Location
        {
            get
            {
                return Entity.Location;
            }
            set
            {
                Entity.Location = value;
                RaisePropertyChanged();
            }
        }

        public string Municipality
        {
            get
            {
                return Entity.Municipality;
            }
            set
            {
                Entity.Municipality = value;
                RaisePropertyChanged("Municipality");
            }
        }

        public string Instructions
        {
            get
            {
                return Entity.Instructions;
            }
            set
            {
                Entity.Instructions = value;
                RaisePropertyChanged("Instructions");
            }
        }

        public Domain.Customer Customer
        {
            get
            {
                return Entity.Customers;
            }
            set
            {
                Entity.Customers = value;
                RaisePropertyChanged("Customer");
            }
        }

        // field
        //private Domain.Inspection Entity;

        public Domain.Inspection toModel()
        {
            return Entity;
        }

        public void AddQuestion(QuestionViewModel question)
        {
            if (Questions.Any(q => q.Id == question.Id))
            {
                return;
            }
            Questions.Add(question);
        }

        public void DeleteQuestion(QuestionViewModel question) //
        {
            question.IsDeleted = true;
        }

        public override bool Save()
        {
            try
            {
                var questionsToUpdate = Questions;
                using (var InspectionRepository = RepositoryFactory.CreateRepository())
                {
                    foreach (var questionViewModel in questionsToUpdate)
                    {
                        // Delete if needed, else try attach
                        if (questionViewModel.IsDeleted)
                            InspectionRepository.DetachQuestions(Entity, questionViewModel.Entity);
                        else
                            InspectionRepository.TryAttachQuestion(Entity, questionViewModel.Entity);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Er is iets fout gegaan");
                return false;
            }

            return true;
        }

        public override void MapValues(Domain.Inspection from, Domain.Inspection to)
        {
            // Call map values on parent model
            MapValues(from, to);

            // Map values
            to.Customer_Id = from.Customer_Id;
            to.Customers = from.Customers;
            to.End = from.End;
            to.InspectionQuestion = from.InspectionQuestion;
            to.Name = from.Name;
            to.Planning = from.Planning;
            to.Start = from.Start;
            to.Status = from.Status;
            to.Status_Status = from.Status_Status;
            to.Website = from.Website;
            to.Instructions = from.Instructions;
        }

        public int Id => Entity.Id;

        public ObservableCollection<QuestionViewModel> Questions { get; }
        

        public QuestionViewModel SelectedQuestion { get; set; }
    }
}
