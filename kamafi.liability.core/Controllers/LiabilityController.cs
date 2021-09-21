using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

using kamafi.liability.services;
using kamafi.liability.data;
using kamafi.liability.services.handlers;

namespace kamafi.liability.core
{
    //[Authorize]
    [ApiController]
    [ApiVersion(Constants.ApiV1)]
    [Route(Constants.ApiRoute)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public class LiabilityController : ControllerBase
    {
        private readonly IAbstractLiabilityHandler _handler;

        public LiabilityController(
            IAbstractLiabilityHandler handler)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        [HttpGet]
        public string Get()
        {
            return "";
        }

        /// <summary>
        /// Add Liability
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody, Required] LiabilityDto dto)
        {
            return Created(nameof(Liability), await _handler.HandleAddAsync(dto));
        }
    }
}
