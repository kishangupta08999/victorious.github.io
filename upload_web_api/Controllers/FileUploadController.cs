using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace upload_web_api.Controllers
{
    public class FileUploadController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> UploadFile()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                var postedFile = httpRequest.Files[0];
                var filePath = HttpContext.Current.Server.MapPath("~/upllds/" + postedFile.FileName);
                postedFile.SaveAs(filePath);

                response = Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return response;
        }
    }
}
