using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Fiap.DesenvolvimentoWeb.WebApi.Basic
{
    public class BasicAuthenticationHandler : DelegatingHandler
    {
        private readonly AuthenticationService _service;
        public BasicAuthenticationHandler(AuthenticationService service)
        {
            _service = service;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            AuthenticationHeaderValue authHeader = request.Headers.Authorization;
            if (authHeader == null || authHeader.Scheme != "Basic")
            {
                return Unauthorized(request);
            }

            string encodedCredentials = authHeader.Parameter;
            byte[] credentialBytes = Convert.FromBase64String(encodedCredentials);
            string[] credentials = Encoding.ASCII.GetString(credentialBytes).Split(':');

            if (!_service.Authenticate(credentials[0], credentials[1]))
            {
                return Unauthorized(request);
            }

            string[] roles = null; // TODO
            IIdentity identity = new GenericIdentity(credentials[0], "Basic");
            IPrincipal user = new GenericPrincipal(identity, roles);
            HttpContext.Current.User = user;
            return base.SendAsync(request, cancellationToken);
        }

        private Task<HttpResponseMessage> Unauthorized(HttpRequestMessage request)
        {
            var response = request.CreateResponse(HttpStatusCode.Unauthorized);
            response.Headers.Add("WWW-Authenticate", "Basic");
            TaskCompletionSource<HttpResponseMessage> task = new
           TaskCompletionSource<HttpResponseMessage>();
            task.SetResult(response);
            return task.Task;
        }
    }
}