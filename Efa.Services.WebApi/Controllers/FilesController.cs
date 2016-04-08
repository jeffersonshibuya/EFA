using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Efa.Services.WebApi.Models;
using Newtonsoft.Json;

namespace Efa.Services.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class FilesController : ApiController
    {

        [HttpPost]
        [Route("files/upload")]
        public HttpResponseMessage Post()
        {
            //return Request.CreateResponse(HttpStatusCode.OK, "ok");
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (ModelState.IsValid)
            {
                if (httpRequest.Files.Count > 0)
                {
                    var docfiles = new List<string>();
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var filePath = HttpContext.Current.Server.MapPath("~/App_Data/" + postedFile.FileName);
                        postedFile.SaveAs(filePath);

                        docfiles.Add(filePath);
                    }
                    result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                result = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
            return result;
        }
    }
}
