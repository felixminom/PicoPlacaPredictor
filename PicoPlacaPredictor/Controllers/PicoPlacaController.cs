using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PicoPlacaPredictor.Models;
using PicoPlacaPredictor.Services;

namespace PicoPlacaPredictor.Controllers
{
    [RoutePrefix("api/PicoPlaca")]
    public class PicoPlacaController : ApiController
    {
        [HttpPost]
        [Route("CanRoad")]
        public IHttpActionResult CanRoad(PicoPlacaModel picoPlaca)
        {
            var service = new PicoPlacaServices();

            return Ok(service.CanRoad(picoPlaca));
        }
        
    }
}
