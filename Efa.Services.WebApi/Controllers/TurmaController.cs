using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Efa.Application.Interfaces;
using System.Web.Http;
using Efa.Application.ViewModels;
using Efa.Services.WebApi.Filters;

namespace Efa.Services.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class TurmaController : ApiController
    {
        private readonly ITurmaAppService _turmaApp;
        private readonly IProfessorAppService _professorApp;
        private readonly IAlunoAppService _alunoApp;

        public TurmaController(ITurmaAppService turmaApp, IProfessorAppService professorApp, IAlunoAppService alunoApp)
        {
            _turmaApp = turmaApp;
            _professorApp = professorApp;
            _alunoApp = alunoApp;
        }

        [HttpGet]
        [GzipCompression]
        [Route("turma")]
        public HttpResponseMessage Get(int skip = 0, int take = 5)
        {            
            var result = _turmaApp.GetAll(skip, take);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("turma/{id}")]
        public HttpResponseMessage GetById(Guid id)
        {
            var result = _turmaApp.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("getturma")]
        public HttpResponseMessage GetTurma()
        {
            var result = _turmaApp.GetTurma();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("turma/professores")]
        public HttpResponseMessage GetProfessores()
        {
            var result = _professorApp.GetAll(0, 5);            
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("turma/alunos")]
        public HttpResponseMessage GetAlunosNaoVinculados()
        {
            var result = _alunoApp.GetAlunosNaoVinculados();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("turma/alunosTurma/{turmaId}")]
        public HttpResponseMessage GetAlunosTurma(Guid turmaId)
        {
            var result = _alunoApp.GetAlunosTurma(turmaId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("turma")]
        public HttpResponseMessage PostTurma(TurmaViewModel turma)
        {
            if (ModelState.IsValid)
            {
                _turmaApp.Add(turma);                    
                return Request.CreateResponse(HttpStatusCode.Created, turma);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPost]
        [Route("turma/addAlunoTurma")]
        public HttpResponseMessage AddAlunoTurma(AlunoTurmaViewModel alunoTurma)
        {
            if (ModelState.IsValid)
            {
                _alunoApp.AddAlunoTurma(alunoTurma.Alunos, alunoTurma.TurmaId);
                return Request.CreateResponse(HttpStatusCode.Created, "Alunos vinculados");
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPut]
        [Route("turma")]
        public HttpResponseMessage SaveTurma(TurmaViewModel turma)
        {
            if (ModelState.IsValid)
            {
                _turmaApp.Update(turma);
                return Request.CreateResponse(HttpStatusCode.OK, turma);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpDelete]
        [Route("turma/{id}")]
        public HttpResponseMessage Delete(Guid id)
        {
            var turma = _turmaApp.GetById(id);
            if (turma == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            //Desvincular os alunos 
            _alunoApp.DesvinculaAlunos(id);

            //Exclui a turma
            _turmaApp.Remove(turma);


            return Request.CreateResponse(HttpStatusCode.OK, turma);
        }
    }
}
