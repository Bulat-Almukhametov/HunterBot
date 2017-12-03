using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotHunter.Models.Infrastructure
{
    public interface IAuthorization
    {
        bool Authenticate(UserCredentials credentials, Guid? serverValue, Func<User, bool> credentialsComparer);
        void LogOff();
        User CurrentUser { get; }
    }
}