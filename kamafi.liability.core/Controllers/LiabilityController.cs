using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

using kamafi.liability.services;
using kamafi.liability.data;

namespace kamafi.liability.core
{
    [Authorize]
    [ApiController]
    [ApiVersion(Constants.ApiV1)]
    [Route(Constants.ApiRoute)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public class LiabilityController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "";
        }
    }
}
