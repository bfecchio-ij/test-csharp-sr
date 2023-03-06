using InfoJobs.Command;
using InfoJobs.Core.Exceptions;
using InfoJobs.Domain.DTO;
using InfoJobs.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfoJobs.UI.Web.Controllers
{
    /// <summary>
    /// Candidates Controller
    /// </summary>
    public class CandidateController : BaseController
    {
        private readonly IMediator _mediator;
        
        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet("candidate/list-all")]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllCandidatesQuery();
            var response = await _mediator.Send(query);
            return View(response);
        }

        [HttpGet("candidate/register-new")]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost("candidate/register-new")]
        public async Task<IActionResult> Create(CreateCandidateDTO model)
        {
            try
            {
                var command = new CreateCandidateCommand(model);
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

       
        [HttpGet("candidate/details/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null) return NotFound();

                var query = new GetCandidateByIdQuery(id.Value);
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

        [HttpGet("candidate/delete/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var query = new GetCandidateByIdQuery(id.Value);
            var response = await _mediator.Send(query);

            return View(response);
        }

        [HttpPost("candidate/delete/{id:int}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var command = new DeleteCandidateCommand(id);
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

        [HttpGet("candidate/edit/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var query = new GetCandidateByIdQuery(id.Value);
            var response = await _mediator.Send(query);

            return View(response);
        }

        [HttpPost("candidate/edit/{id:int}")]
        public async Task<IActionResult> Edit(UpdateCandidateDTO model)
        {
            try
            {
                var command = new UpdateCandidateCommand(model, model.Id);
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