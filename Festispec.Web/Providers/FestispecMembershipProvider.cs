using System;
using System.Linq;
using System.Web.Security;
using Festispec.Domain;
using Festispec.Domain.Encryption;
using Festispec.Domain.Repository.Factory;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Web.Models;

namespace Festispec.Web.Providers
{
    public class FestispecMembershipProvider : MembershipProvider
    {
        private readonly ILoginRepositoryFactory _loginRepositoryFactory;
        private readonly IInspectorRepositoryFactory _inspectorRepositoryFactory;

        public FestispecMembershipProvider()
        {
            _loginRepositoryFactory = new LoginRepositoryFactory(true);
            _inspectorRepositoryFactory = new InspectorRepositoryFactory(true);
        }

        public override bool EnablePasswordRetrieval { get; }
        public override bool EnablePasswordReset { get; }
        public override bool RequiresQuestionAndAnswer { get; }
        public override string ApplicationName { get; set; }
        public override int MaxInvalidPasswordAttempts { get; }
        public override int PasswordAttemptWindow { get; }
        public override bool RequiresUniqueEmail { get; }
        public override MembershipPasswordFormat PasswordFormat { get; }
        public override int MinRequiredPasswordLength { get; }
        public override int MinRequiredNonAlphanumericCharacters { get; }
        public override string PasswordStrengthRegularExpression { get; }

        public override MembershipUser CreateUser(string username, string password, string email,
            string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            // Not supported in the web application. Only in desktop application.
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password,
            string newPasswordQuestion,
            string newPasswordAnswer)
        {
            // Not supported in the web application. Only in desktop application.
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            // Not supported in the web application. Only in desktop application.
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            // Not supported in the web application. Only in desktop application.
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            // Not supported in the web application. Only in desktop application.
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            // Not supported in the web application. Only in desktop application.
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            using (var loginRepository = _inspectorRepositoryFactory.CreateRepository())
            {
                return loginRepository.TryLogin(GetUserNameByEmail(username), Cryptography.Encrypt(password));
            }
        }

        public override bool UnlockUser(string userName)
        {
            // Not supported in the web application. Only in desktop application.
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            using (var inspectorRepository = _inspectorRepositoryFactory.CreateRepository())
            {
                var employee = inspectorRepository.Get(providerUserKey);

                return employee?.ConvertToMembershipUser();
            }
        }

        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            using (var inspectorRepository = _inspectorRepositoryFactory.CreateRepository())
            {
                var employee = inspectorRepository.Find(e => e.Email == email);

                return employee?.ConvertToMembershipUser();
            }
        }

        public override string GetUserNameByEmail(string email)
        {
            using (var loginRepository = _loginRepositoryFactory.CreateRepository())
            {
                var employee = loginRepository.Get().FirstOrDefault(e => e.Email == email);

                return employee != null ? employee.Username : string.Empty;
            }
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            // Not supported in the web application. Only in desktop application.
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            // Not supported in the web application. Only in desktop application.
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            // Not supported in the web application. Only in desktop application.
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize,
            out int totalRecords)
        {
            // Not supported in the web application. Only in desktop application.
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize,
            out int totalRecords)
        {
            // Not supported in the web application. Only in desktop application.
            throw new NotImplementedException();
        }
    }

    internal static class FestispecMembershipProviderExtensions
    {
        public static MembershipUser ConvertToMembershipUser(this Inspector employee)
        {
            return new MembershipUser(nameof(FestispecMembershipProvider), employee.Username, employee.Id, employee.Email, null,
                null, true,
                false, DateTime.MinValue, DateTime.Now, DateTime.Now, DateTime.MinValue, DateTime.MinValue);
        }
    }
}