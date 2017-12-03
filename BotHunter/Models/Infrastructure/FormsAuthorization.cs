using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;

namespace BotHunter.Models.Infrastructure
{
    public class FormsAuthorization : IAuthorization
    {
        DataRepository _DataRepository;
        public FormsAuthorization(DataRepository dataRepository)
        {
            _DataRepository = dataRepository;
        }

        public User CurrentUser {
            get
            {
                User currentUser = (User)HttpContext.Current.Session["CurrentUser"];
                if (currentUser == null)
                {
                    string cookieName = FormsAuthentication.FormsCookieName;
                    HttpCookie authCookie = HttpContext.Current.Request.Cookies[cookieName];
                    if (authCookie != null)
                    {
                        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                        string login = ticket.Name;

                        currentUser = _DataRepository.SysUsers.FirstOrDefault(u => u.Login == login);
                        HttpContext.Current.Session["CurrentUser"] = currentUser;
                        
                    }
                }
                if (currentUser == null)
                {
                    FormsAuthentication.SignOut();
                    return null;
                }
                else
                {
                    return currentUser;
                }
            }
        }

        public bool Authenticate(UserCredentials credentials, Guid? bigNumber,
            Func<User, bool> credentialsComparer = null)
        {
            // проверяем входящие параметры
            if (bigNumber != null && credentials.Login != null && credentials.HashValue != null)
            {
                if (credentialsComparer == null)
                {
                    credentialsComparer = u => u.Login == credentials.Login;
                }
                User user = _DataRepository.SysUsers.First(credentialsComparer);
                if (user != null)
                {
                    // получаем строку хеша числа, переданному клиенту сервером, и хеша пароля из БД
                    var sha = new SHA1CryptoServiceProvider();
                    var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(user.Password + bigNumber));
                    var hashString = BitConverter.ToString(hash).Replace("-", "");

                    // если хеши совпали, то пользователь ввел правильные логин\пароль
                    if (credentials.HashValue.Equals(hashString, StringComparison.OrdinalIgnoreCase))
                    {
                        FormsAuthentication.SetAuthCookie(credentials.Login, true);
                        HttpContext.Current.Session["CurrentUser"] = user;

                        return true;
                    }
                }
            }

            return false;
        }

        public void LogOff()
        {
            FormsAuthentication.SignOut();
        }
    }
}