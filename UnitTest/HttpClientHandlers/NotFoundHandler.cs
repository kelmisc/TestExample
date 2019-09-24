using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace UnitTest.HttpClientHandlers
{
    public class NotFoundHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = new HttpConfiguration();
            return Task.FromResult(request.CreateResponse(HttpStatusCode.NotFound, new { }));
        }
    }
}
