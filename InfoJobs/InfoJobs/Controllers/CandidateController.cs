using InfoJobs.Command;
using InfoJobs.Core.Exceptions;
using InfoJobs.Domain.DTO;
using InfoJobs.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InfoJobs.API.Controllers
{
    /// <summary>
    /// Candidates Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor for Candidates Controller
        /// </summary>
        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all Candidates with related Experiences
        /// </summary>
        /// <response code="200">Candidates retrieved</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CandidateDTO>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCandidatesQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Creates a new Candidate
        /// </summary>
        /// <response code="201">Candidate added</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Candidate([FromBody] CreateCandidateDTO model)
        {
            try
            {
                var command = new CreateCandidateCommand(model);
                var response = await _mediator.Send(command);
                return StatusCode((int)HttpStatusCode.Created, response);
            }
            catch (InvalidRequestBodyException ex)
            {
                return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                });
            }
        }

        /// <summary>
        /// Retrieves a specific Candidate by id including related Experiences
        /// </summary>
        /// <response code="200">Candidate retrieved</response>
        /// <response code="404">Candidate not found</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(CandidateDTO), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = new GetCandidateByIdQuery(id);
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = new string[] { ex.Message }
                });
            }
        }

        /// <summary>
        /// Deletes a Candidate
        /// </summary>
        /// <response code="200">Candidate deleted</response>
        /// <response code="400">Bad Request</response>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteCandidateCommand(id);
                var response = await _mediator.Send(command);
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (InvalidRequestBodyException ex)
            {
                return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                });
            }
        }

        /// <summary>
        /// Updates a Candidate
        /// </summary>
        /// <response code="200">Candidate updated</response>
        /// <response code="400">Bad Request</response>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] UpdateCandidateDTO model, int id)
        {
            try
            {
                var command = new UpdateCandidateCommand(model, id);
                var response = await _mediator.Send(command);
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (InvalidRequestBodyException ex)
            {
                return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                });
            }
        }
    }
}
