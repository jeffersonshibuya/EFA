using Efa.Application.Interfaces;
using Efa.Application.ViewModels;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Efa.Services.WebApi.Filters;

namespace Efa.Services.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class ProfessorController : ApiController
    {
        private readonly IProfessorAppService _professorApp;
        private readonly ITurmaAppService _turmaApp;

        public ProfessorController(IProfessorAppService professorApp, ITurmaAppService turmaApp)
        {
            _professorApp = professorApp;
            _turmaApp = turmaApp;
        }

        [HttpGet]
        [GzipCompression]
        [Route("professores")]
        public HttpResponseMessage GetProfessores(int skip = 0, int take = 5)
        {
            var result = _professorApp.GetAll(skip, take);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("professores")]
        public HttpResponseMessage PostProfessor(ProfessorViewModel professor)
        {
            if (ModelState.IsValid)
            {
                if (professor.CPF == "")
                    professor.CPF = null;
                var result = _professorApp.Add(professor);

                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Erros)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return Request.CreateResponse(HttpStatusCode.Created, professor);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPut]
        [Route("professores")]
        public HttpResponseMessage Put(ProfessorViewModel professor)
        {
            if (ModelState.IsValid)
            {
                var result = _professorApp.Editar(professor);
                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Erros)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

                }

                return Request.CreateResponse(HttpStatusCode.OK, professor);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpDelete]
        [Route("professor/{id}")]
        public HttpResponseMessage Delete(Guid id)
        {
            var professor = _professorApp.GetById(id);
            if (professor == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            //Set null ProfessorId em turmas
            _turmaApp.DesvinculaProfessor(id);

            _professorApp.Remove(professor);


            return Request.CreateResponse(HttpStatusCode.OK, professor);
        }

        protected override void Dispose(bool disposing)
        {
            _professorApp.Dispose();
            base.Dispose(disposing);
        }       
    }
}
