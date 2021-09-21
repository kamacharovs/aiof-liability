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
    //[Authorize]
    [ApiController]
    [ApiVersion(Constants.ApiV1)]
    [Route(Constants.ApiRoute)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public class LiabilityController : ControllerBase
    {
        private readonly ILiabilityRepository _repo;

        public LiabilityController(
            ILiabilityRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
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
        public async Task<IActionResult> AddAsync(
            [FromBody, Required] object dto,
            [FromQuery, Required] string type)
        {
            return Created(nameof(Liability), await _repo.AddAsync(dto, type));
        }
    }
}
