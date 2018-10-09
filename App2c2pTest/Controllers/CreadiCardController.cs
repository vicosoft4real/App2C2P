using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace App2c2pTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreadiCardController : ControllerBase
    {
        // GET api/values
         
        // GET api/values/5
        [HttpGet("{card}")]
        public ActionResult<string> GetCard(string card)
        {
            return "value";
        }

       
        
    }
}
