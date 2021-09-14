using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace kamafi.liability.core
{
    [ApiController]
    [Route("[controller]")]
    public class LiabilityController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "";
        }
    }
}
