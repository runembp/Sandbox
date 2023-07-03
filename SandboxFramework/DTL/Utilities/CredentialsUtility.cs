using System;
using SimpleImpersonation;

namespace DTL.Utilities
{
    public static class CredentialsUtility
    {
        private const string SystemAdministratorUsername = "SA_USERNAME";
        private const string SystemAdministratorPassword = "SA_PASSWORD";
        private const string SystemAdministratorDomain = "SA_DOMAIN";

        public static UserCredentials GetSystemAdministratorCredentials()
        {
            var username = Environment.GetEnvironmentVariable(SystemAdministratorUsername, EnvironmentVariableTarget.Machine);
            var password = Environment.GetEnvironmentVariable(SystemAdministratorPassword, EnvironmentVariableTarget.Machine);
            var domain = Environment.GetEnvironmentVariable(SystemAdministratorDomain, EnvironmentVariableTarget.Machine);
            return new UserCredentials(domain, username, password);
        }
    }
}