using System;
using Efa.Application.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Efa.Application.ViewModels;

namespace Efa.Services.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class NotasController : ApiController
    {
        private readonly INotasAppService _notasApp;
        private readonly IAlunoAppService _alunoApp;

        public NotasController(INotasAppService notasApp, IAlunoAppService alunoApp)
        {
            _notasApp = notasApp;
            _alunoApp = alunoApp;
        }

        [HttpGet]
        [Route("notas")]
        public HttpResponseMessage GetNotas(int skip = 0, int take = 5)
        {
            var result = _notasApp.GetAll(skip, take);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("notas/aluno/{id}")]
        public HttpResponseMessage GetNotasByAluno(Guid id)
        {
            var result = _notasApp.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("notas/{id}")]
        public HttpResponseMessage PostNotas(Guid id, NotasViewModel notas)
        {            
            if (ModelState.IsValid)
            {          
                //Add Notas
                _notasApp.Add(notas);

                //Atualiza notas em aluno
                var aluno = _alunoApp.GetById(id);
                aluno.NotasId = notas.NotasId;
                _alunoApp.Update(aluno);

                return Request.CreateResponse(HttpStatusCode.Created, notas);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPut]
        [Route("notas")]
        public HttpResponseMessage Put(NotasViewModel notas)
        {
            if (ModelState.IsValid)
            {
                _notasApp.Update(notas);
                return Request.CreateResponse(HttpStatusCode.OK, notas);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpDelete]
        [Route("notas/{id}/{alunoId}")]
        public HttpResponseMessage Delete(Guid id, Guid alunoId)
        {
            var notas = _notasApp.GetById(id);
            if (notas == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            //Atualiza notas em aluno
            var aluno = _alunoApp.GetById(alunoId);
            aluno.NotasId = null;
            _alunoApp.Update(aluno);

            _notasApp.Remove(notas);
            return Request.CreateResponse(HttpStatusCode.OK, notas);
        }

        protected override void Dispose(bool disposing)
        {
            _notasApp.Dispose();
            base.Dispose(disposing);
        }       
    }
}
