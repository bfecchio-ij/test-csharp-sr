using InfoJobs.KnowledgeTest.Application.Curriculum.Service.Interfaces;
using InfoJobs.KnowledgeTest.Application.Curriculum.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InfoJobs.KnowledgeTest.Data.Infra.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateExperienceController : ControllerBase
    {
        private readonly ICandidateExperienceApp _candidateExperienceApp;

        public CandidateExperienceController(ICandidateExperienceApp candidateExperienceApp)
        {
            _candidateExperienceApp = candidateExperienceApp;
        }

        [HttpPost]
        [Route("AddCandidateExperience")]
        public async Task<IActionResult> Add([FromBody] CandidateExperienceViewModel candidateExperience)
        {
            try
            {
                if (ModelState.IsValid)
                    await _candidateExperienceApp.Add(candidateExperience);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("DeleteCandidateExperience/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _candidateExperienceApp.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("UpdateCandidateExperience")]
        public async Task<IActionResult> Update([FromBody] CandidateExperienceViewModel candidateExperience)
        {
            try
            {
                if (ModelState.IsValid)
                    await _candidateExperienceApp.Update(candidateExperience);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("ListByCandidate/{idCandidate}")]
        public IActionResult List(int idCandidate)
        {
            try
            {
                var lstCandidates = _candidateExperienceApp.ListByCandidate(idCandidate);
                return Ok(lstCandidates);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("GetCandidateExperience/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var oCandidateExperience = _candidateExperienceApp.GetById(id);
                return Ok(oCandidateExperience);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
