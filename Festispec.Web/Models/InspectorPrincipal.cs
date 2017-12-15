using System;
using System.Security.Principal;
using System.Web.Security;
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

    public class InspectorMembershipUser : MembershipUser
    {
        public InspectorMembershipUser(string providerName, string name, object providerUserKey, string email,
            string passwordQuestion, string comment, bool isApproved, bool isLockedOut, DateTime creationDate,
            DateTime lastLoginDate, DateTime lastActivityDate, DateTime lastPasswordChangedDate,
            DateTime lastLockoutDate) : base(providerName, name, providerUserKey, email, passwordQuestion, comment,
            isApproved, isLockedOut, creationDate, lastLoginDate, lastActivityDate, lastPasswordChangedDate,
            lastLockoutDate)
        {
        }
    }
}