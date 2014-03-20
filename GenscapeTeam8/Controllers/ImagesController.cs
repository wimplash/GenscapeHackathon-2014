using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;

namespace GenscapeTeam8.Controllers
{
    public class ImagesController : ApiController
    {
        public HttpResponseMessage Get(HttpRequestMessage request, [FromUri] int id, [FromUri] long timestamp)
        {
            byte[] imgData = new byte[];
            MemoryStream ms = new MemoryStream(imgData);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
            return response;
        }

        // POST api/images
        public HttpResponseMessage Post(HttpRequestMessage request, [FromUri] int id, [FromUri] long timestamp)
        {
            return request.CreateResponse(HttpStatusCode.Created);
        }
    }
}