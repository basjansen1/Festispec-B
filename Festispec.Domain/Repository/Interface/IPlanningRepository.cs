using System.Linq;

namespace Festispec.Domain.Repository.Interface
{
    public interface IPlanningRepository : IRepository<Planning>
    {
        IQueryable<Planning> GetByInspectionId(int inspectionId);
    }
}