using Efa.Application.Interfaces;
using Efa.Application.ViewModels;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Efa.Services.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class ContatoPessoaController : ApiController
    {
        private readonly IContatoPessoaAppService _contatoPessoaApp;

        public ContatoPessoaController(IContatoPessoaAppService contatoPessoaApp)
        {
            _contatoPessoaApp = contatoPessoaApp;
        }

        [HttpGet]
        [Route("contatos")]
        public HttpResponseMessage Get()
        {
            var result = _contatoPessoaApp.GetContatos();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("contatos")]
        public HttpResponseMessage PostContato(ContatoPessoaViewModel contatoPessoa)
        {
            if (ModelState.IsValid)
            {
                _contatoPessoaApp.Add(contatoPessoa);
                return Request.CreateResponse(HttpStatusCode.Created, contatoPessoa);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPut]
        [Route("contatos")]
        public HttpResponseMessage SaveContato(ContatoPessoaViewModel contatoPessoa)
        {
            if (ModelState.IsValid)
            {
                _contatoPessoaApp.Update(contatoPessoa);
                return Request.CreateResponse(HttpStatusCode.OK, contatoPessoa);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpDelete]
        [Route("contatos/{id}")]
        public HttpResponseMessage Delete(Guid id)
        {
            var contatoPessoa = _contatoPessoaApp.GetById(id);
            if (contatoPessoa == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            //excluir pessoas do grupo 

            //Exclui grupo
            _contatoPessoaApp.Remove(contatoPessoa);


            return Request.CreateResponse(HttpStatusCode.OK, contatoPessoa);
        }
    }
}
