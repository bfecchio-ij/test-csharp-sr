using LinkedinTest.Data;
using LinkedinTest.Domain.Commands.Handlers;
using LinkedinTest.Domain.Commands.Request;
using LinkedinTest.Domain.Commands.Responses;
using LinkedinTest.Model;
using LinkedinTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LinkedinTest.Controllers
{
    public class CandidateController : ControllerBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        [HttpGet]
        [Route("GetCandidates")]
        public ActionResult<List<CandidateModel>> GetCandidates()
        {
            var candidates = unitOfWork.CandidateRepo().Get().ToList();
            return Ok(candidates);
        }

        [HttpPost]
        public ActionResult CreateCandidate()
        {
            return null;
        }
    }
}
