using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tonline.Models
{
    public class ResponseModel : Controller
    {
        // GET: ResponseModel
        public bool respuesta { get; set; }
        public string error { get; set; }
    }
}