using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.DesenvolvimentoWeb.WebApi.Basic
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool Authenticate(string user, string password)
        {
            //implementar as verificações necessárias
            return user.Equals("admin") && password.Equals("0000");
        }
    }
}