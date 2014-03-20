using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GenscapeTeam8.Controllers
{
    public class ImagesController : ApiController
    {
        // POST api/images
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            return request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
