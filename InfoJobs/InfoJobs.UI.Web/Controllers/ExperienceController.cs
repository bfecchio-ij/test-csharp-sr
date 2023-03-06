using InfoJobs.Command;
using InfoJobs.Core.Exceptions;
using InfoJobs.Domain.DTO;
using InfoJobs.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfoJobs.UI.Web.Controllers
{
    /// <summary>
    /// Experiences Controller
    /// </summary>    
    public class ExperienceController : BaseController
    {
        private readonly IMediator _mediator;
        
        public ExperienceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("experience/list-all")]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllExperiencesQuery();
            var response = await _mediator.Send(query);
            return View(response);
        }

        [HttpGet("experience/register-new")]
        public IActionResult Create(int? id)
        {
            if(id != null)
                ViewData["CandidateId"] = id;

            return View();
        }

        [HttpPost("experience/register-new")]
        public async Task<IActionResult> Create(CreateExperienceDTO model)
        {
            try
            {
                var command = new CreateExperienceCommand(model);
                var response = await _mediator.Send(command);
                return RedirectToAction("Index");
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

        [HttpGet("experience/details/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null) return NotFound();

                var query = new GetExperienceByIdQuery(id.Value);
                var response = await _mediator.Send(query);
                return View(response);
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

        [HttpGet("experience/candidate-details/{id:int}")]
        public async Task<IActionResult> CandidateDetails(int? id)
        {
            try
            {
                if (id == null) return NotFound();

                var query = new GetExperiencesByCandidateIdQuery(id.Value);
                var response = await _mediator.Send(query);
                return View(response);
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

        [HttpGet("experience/delete/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var query = new GetExperienceByIdQuery(id.Value);
            var response = await _mediator.Send(query);

            return View(response);
        }

        [HttpPost("experience/delete/{id:int}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var command = new DeleteExperienceCommand(id);
                var response = await _mediator.Send(command);
                return RedirectToAction("Index");
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

        [HttpGet("experience/edit/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var query = new GetExperienceByIdQuery(id.Value);
            var response = await _mediator.Send(query);

            return View(response);
        }

        [HttpPost("experience/edit/{id:int}")]
        public async Task<IActionResult> Edit(UpdateExperienceDTO model)
        {
            try
            {
                var command = new UpdateExperienceCommand(model, model.Id);
                var response = await _mediator.Send(command);
                return RedirectToAction("Index");
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
