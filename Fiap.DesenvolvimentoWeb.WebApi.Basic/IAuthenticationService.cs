using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.DesenvolvimentoWeb.WebApi.Basic
{
    public interface IAuthenticationService
    {
        bool Authenticate(string user, string password);
    }
}
