using System.Security.Principal;
using Festispec.Domain;

namespace Festispec.Web.Models
{
    public interface IInspectorPrincipal : IPrincipal
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }

    public class InspectorPrincipal : Inspector, IInspectorPrincipal
    {
        public InspectorPrincipal(string email)
        {
            Identity = new GenericIdentity(email);
        }

        public bool IsInRole(string role)
        {
            return false;
        }

        public IIdentity Identity { get; }
    }

    public class InspectorPrincipalSerializeModel : Inspector
    {
    }
}