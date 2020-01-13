using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PicoPlacaPredictor.Controllers
{
    [RoutePrefix("api/PicoPlaca")]
    public class PicoPlacaController : ApiController
    {
        [HttpPost]
        [Route("CanRoad")]
        public IHttpActionResult CanRoad()
        {
            return Ok(true);
        }
        
    }
}
