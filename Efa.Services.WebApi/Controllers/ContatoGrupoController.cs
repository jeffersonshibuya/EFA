using Efa.Application.Interfaces;
using Efa.Application.ViewModels;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Efa.Services.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class ContatoGrupoController : ApiController
    {
        private readonly IContatoGrupoAppService _contatoGrupoApp;
        private readonly IContatoPessoaAppService _contatoPessoaApp;

        public ContatoGrupoController(IContatoGrupoAppService contatoGrupoApp, IContatoPessoaAppService contatoPessoaApp)
        {
            _contatoGrupoApp = contatoGrupoApp;
            _contatoPessoaApp = contatoPessoaApp;
        }

        [HttpGet]
        [Route("grupos")]
        public HttpResponseMessage Get(int skip = 0, int take = 5)
        {
            var result = _contatoGrupoApp.GetAll(skip, take);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("gruposPessoas")]
        public HttpResponseMessage Get()
        {
            var result = _contatoGrupoApp.GetGrupos();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("grupos")]
        public HttpResponseMessage PostGrupo(ContatoGrupoViewModel contatoGrupo)
        {
            if (ModelState.IsValid)
            {
                _contatoGrupoApp.Add(contatoGrupo);
                return Request.CreateResponse(HttpStatusCode.Created, contatoGrupo);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPut]
        [Route("grupos")]
        public HttpResponseMessage SaveGrupo(ContatoGrupoViewModel contatoGrupo)
        {
            if (ModelState.IsValid)
            {
                _contatoGrupoApp.Update(contatoGrupo);
                return Request.CreateResponse(HttpStatusCode.OK, contatoGrupo);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpDelete]
        [Route("grupos/{id}")]
        public HttpResponseMessage Delete(Guid id)
        {
            var contatoGrupo = _contatoGrupoApp.GetById(id);
            if (contatoGrupo == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            //excluir pessoas do grupo 
            _contatoPessoaApp.RemoveFromGruoup(id);

            //Exclui grupo
            _contatoGrupoApp.Remove(contatoGrupo);


            return Request.CreateResponse(HttpStatusCode.OK, contatoGrupo);
        }
    }
}
