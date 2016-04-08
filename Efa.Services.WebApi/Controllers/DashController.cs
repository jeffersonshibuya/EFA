using Efa.Application.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Efa.Services.WebApi.Controllers
{
    [RoutePrefix("api")]
    [Authorize]
    public class DashController : ApiController
    {
        private readonly IDashAppService _dashApp;

        public DashController(IDashAppService dashApp)
        {
            _dashApp = dashApp;
        }

        [HttpGet]
        [Route("dash")]
        public HttpResponseMessage Dash()
        {
            var result = _dashApp.Dash();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
