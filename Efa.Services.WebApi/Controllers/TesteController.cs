using Efa.Application.ViewModels;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Efa.Services.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class TesteController : ApiController
    {
        [HttpPost]
        [Route("teste")]
        public HttpResponseMessage Post(TesteViewModel teste)
        {
            if (ModelState.IsValid)
            {                
                return Request.CreateErrorResponse(HttpStatusCode.Created, "Tudo OK");
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}
