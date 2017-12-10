using Festispec.Domain;
using Festispec.Domain.Repository.Factory;

namespace DatabaseTest
{
    internal class Program
    {
        private static readonly Inspection Inspection = new Inspection
        {
            Id = 0,
            Name = "Test Inspection 1"
        };

        private static readonly Question Question = new Question
        {
            Id = 4,
            Name = "Test Question 1",
            Description = "Test Question 1 Description",
            QuestionType_Type = "Tekst"
        };

        private static void Main(string[] args)
        {
            TestInspectionAdd();
//            TestInspectionQuestionAdd();
        }

        private static void TestInspectionAdd()
        {
            using (var repository = new InspectionRepositoryFactory(true).CreateRepository())
            {
                repository.Add(Inspection);
            }
        }

        private static void TestInspectionQuestionAdd()
        {
            using (var repository = new InspectionRepositoryFactory(true).CreateRepository())
            {
//                repository.AddQuestion(Inspection, Question);
            }
        }
    }
}