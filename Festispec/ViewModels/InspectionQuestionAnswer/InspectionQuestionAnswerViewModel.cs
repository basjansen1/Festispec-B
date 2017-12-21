using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
