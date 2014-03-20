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
        //get first image for source
        public HttpResponseMessage Get(HttpRequestMessage request, [FromUri] int id)
        {
            byte[] imgData = new byte[0];
            MemoryStream ms = new MemoryStream(imgData);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
            return response;
        }

        //get image for source for timestamp
        public HttpResponseMessage Get(HttpRequestMessage request, [FromUri] int id, [FromUri] long timestamp)
        {
            byte[] imgData = new byte[0];
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