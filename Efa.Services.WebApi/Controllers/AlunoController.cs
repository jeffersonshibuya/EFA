using Efa.Application.Interfaces;
using Efa.Application.ViewModels;
using Efa.Services.WebApi.Filters;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Efa.Services.WebApi.Controllers
{
    [RoutePrefix("api")]
    //[AutoInvalidateCacheOutput]
    [Authorize]
    public class AlunoController : ApiController
    {
        private readonly IAlunoAppService _alunoApp;

        public AlunoController(IAlunoAppService alunoApp)
        {
            _alunoApp = alunoApp;
        }


        [HttpGet]
        [Route("alunos/teste")]
        //[InvalidateCacheOutput("Get")]
        public HttpResponseMessage GetTeste()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Teste");
        }
      
        [HttpGet]
        [Route("alunos")]
        //[GzipCompression]
        //[CacheOutput(ClientTimeSpan = 300, ServerTimeSpan = 300)]
        public async Task<HttpResponseMessage> Get()
        {
            var result = _alunoApp.GetAlunos();
            var response = Request.CreateResponse(HttpStatusCode.OK, result);

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return await tsc.Task;
        }

        [HttpPost]
        [Route("alunos")]
        public HttpResponseMessage Post(AlunoViewModel aluno)
        {
            if (ModelState.IsValid)
            {
                var result = _alunoApp.Add(aluno);

                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Erros)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return Request.CreateResponse(HttpStatusCode.Created, aluno);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPut]
        [Route("alunos")]
        public HttpResponseMessage Put(AlunoViewModel aluno)
        {
            if (ModelState.IsValid)
            {
                var result = _alunoApp.Editar(aluno);
                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Erros)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

                }

                return Request.CreateResponse(HttpStatusCode.OK, aluno);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpDelete]
        [Route("alunos/{id}")]
        //[InvalidateCacheOutput("Get")]
        public Task<HttpResponseMessage> Delete(Guid id)
        {
            var aluno = _alunoApp.GetById(id);

            var response =  new HttpResponseMessage();

            if (aluno == null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                _alunoApp.Remove(aluno);
                response = Request.CreateResponse(HttpStatusCode.OK, "Aluno Excluído");
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        protected override void Dispose(bool disposing)
        {
            _alunoApp.Dispose();
            base.Dispose(disposing);
        }       
    }
}
