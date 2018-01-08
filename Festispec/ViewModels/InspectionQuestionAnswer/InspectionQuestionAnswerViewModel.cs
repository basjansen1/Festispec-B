using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festispec.Domain;

namespace Festispec.ViewModels
{
    public class InspectionQuestionAnswerViewModel : EntityViewModelBase<IInspectionQuestionAnswerRepositoryFactory, IInspectionQuestionAnswerRepository, Domain.InspectionQuestionAnswer>
    {
        public InspectionQuestionAnswerViewModel(IInspectionQuestionAnswerRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
            
        }

        public InspectionQuestionAnswerViewModel(IInspectionQuestionAnswerRepositoryFactory repositoryFactory, Domain.InspectionQuestionAnswer entity)
            : base(repositoryFactory, entity)
        {
        }


        public string answer
        {
            get
            {
                return Entity.Answer;
            }
            set
            {
                Entity.Answer = value;
                RaisePropertyChanged();
            }
        }

        public override bool Save()
        {
            return true;
        }

        public override void MapValues(InspectionQuestionAnswer from, InspectionQuestionAnswer to)
        {
            // Map values-
            to.Answer = from.Answer;
            to.Date = from.Date;
            to.Inspection_Id = from.Inspection_Id;
            to.Inspector_Id = from.Inspector_Id;
            to.Question_Id = from.Question_Id;
            to.InspectionQuestion = from.InspectionQuestion;
            to.Planning = from.Planning;
        }
    }
}
