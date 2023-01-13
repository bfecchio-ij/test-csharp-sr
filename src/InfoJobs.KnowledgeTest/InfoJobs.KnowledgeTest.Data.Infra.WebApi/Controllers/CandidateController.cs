using InfoJobs.KnowledgeTest.Application.Curriculum.Service.Interfaces;
using InfoJobs.KnowledgeTest.Application.Curriculum.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InfoJobs.KnowledgeTest.Data.Infra.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateApp _candidateApp;

        public CandidateController(ICandidateApp candidateApp)
        {
            _candidateApp = candidateApp;
        }


        [HttpPost]
        [Route("AddCandidate")]
        public async Task<IActionResult> Add([FromBody] CandidateViewModel candidate)
        {
            try
            {
                int idCandidate = 0;

                if (ModelState.IsValid)
                    idCandidate = await _candidateApp.Add(candidate);

                return Ok(idCandidate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("DeleteCandidate/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _candidateApp.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("UpdateCandidate")]
        public async Task<IActionResult> Update([FromBody] CandidateViewModel candidate)
        {
            try
            {
                if (ModelState.IsValid)
                    await _candidateApp.Update(candidate);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ListCandidate")]
        public IActionResult List()
        {
            try
            {
                var lstCandidate = _candidateApp.List();
                return Ok(lstCandidate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("GetCandidate/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var oCandidate = _candidateApp.GetById(id);
                return Ok(oCandidate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
