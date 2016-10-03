using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.DesenvolvimentoWeb.WebApi.Basic
{
    public class ProdutosRepositorio : IProdutosRepositorio
    {
        public IEnumerable<string> BuscarTodos()
        {
            return new List<String> { "mob", "net", "scj" };
        }
    }
}
