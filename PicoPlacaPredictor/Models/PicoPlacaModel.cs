using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PicoPlacaPredictor.Models
{
    public class PicoPlacaModel
    {
        public int PlateNumber { get; set;}
        public string Date { get; set;}
        public string Time { get; set; }
    }

    public class PicoPlacaResponseModel
    {
        public bool CanRoad { get; set; }
        public string Message { get; set; }
    }
}