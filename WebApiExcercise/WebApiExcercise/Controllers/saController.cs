using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;

namespace WebApiExcercise.Controllers
{
    [RoutePrefix("na")]
    public class saController : ApiController
    {
        [Route("all")]
        public HttpResponseMessage Get()
        {
           
            return Request.CreateResponse(HttpStatusCode.OK, "found");
            // throw new ApiDataException(1000, "Products not found", HttpStatusCode.NotFound);
        }

    }
}
