using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.DesenvolvimentoWeb.WebApi.Basic
{
    public interface IProdutosRepositorio
    {
        IEnumerable<string> BuscarTodos();
    }
}
