using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fiap.DesenvolvimentoWeb.WebApi.Basic.Controllers
{
    public class ProdutosController : ApiController
    {
        static readonly IProdutosRepositorio repositorio = new ProdutosRepositorio();

        [Authorize]
        public IEnumerable<String> GetAllProducts()
        {
            return repositorio.BuscarTodos();
        }
    }
}
