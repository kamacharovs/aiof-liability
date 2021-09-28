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
        private readonly ILiabilityRepository _repo;

        public LiabilityController(
            ILiabilityRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        /// <summary>
        /// Add Liability
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(kamafi.core.data.IKamafiProblemDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ILiability), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddAsync([FromBody, Required] LiabilityDto dto)
        {
            return Created(nameof(Liability), await _repo.AddAsync(dto));
        }

        /// <summary>
        /// Delete Liability
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(kamafi.core.data.IKamafiProblemDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task <IActionResult> DeleteAsync([FromRoute, Required] int id)
        {
            await _repo.DeleteAsync(id);

            return Ok();
        }
    }
}
