using InfoJobs.KnowledgeTest.UI.Web.ApiHelper.Api;
using InfoJobs.KnowledgeTest.UI.Web.ApiHelper.ViewModels.Curriculum;
using InfoJobs.KnowledgeTest.UI.Web.Areas.Curriculum.ViewModels.Candidate;
using InfoJobs.KnowledgeTest.UI.Web.Controllers;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace InfoJobs.KnowledgeTest.UI.Web.Areas.Curriculum.Controllers
{
    [Area("Curriculum")]
    [Route("Curriculum/[controller]")]
    public class CandidateController : BaseController
    {
        public CandidateController(IConfiguration configuration) : base(configuration)
        { }

        #region Index

        [Route("Index")]
        [HttpGet]

        public IActionResult Index()
        {
            IndexViewModel oIndexVM = new();

            try
            {
                oIndexVM.Candidates = CandidateHelper.ListCandidate(_hostWebApi);
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return View(oIndexVM);
        }

        [Route("Delete/{idCandidate}")]
        [HttpPost]
        public JsonResult Delete(int idCandidate)
        {
            try
            {
                CandidateHelper.DeleteCandidate(_hostWebApi, idCandidate);
                return Json(new { FlSucesso = true, Mensagem = "Candidate deleted successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = true, Mensagem = ex.Message });
            }
        }

        #endregion

        #region Register               

        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register", new RegisterViewModel());
        }

        [Route("Register")]
        [HttpPost]
        public JsonResult Register(CandidateViewModel candidate)
        {
            try
            {
                int idCandidate = CandidateHelper.AddCandidate(_hostWebApi, candidate);
                return Json(new { FlSucesso = true, IdCandidate = idCandidate, Mensagem = "Successfully Registered Candidate" });
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }

        [Route("Edit/{id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oRegister = new RegisterViewModel();

            try
            {
                oRegister.Candidate = CandidateHelper.GetCandidate(_hostWebApi, id);
                oRegister.CandidateExperience = CandidateExperienceHelper.ListByCandidate(_hostWebApi, id).ToList();
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return View("Register", oRegister);
        }

        [Route("Edit")]
        [HttpPost]
        public JsonResult Edit(CandidateViewModel candidate)
        {
            try
            {
                CandidateHelper.UpdateCandidate(_hostWebApi, candidate);
                return Json(new { FlSucesso = true, Mensagem = "Successfully Updated Candidate" });
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }

        #endregion

        #region Experience

        [Route("RegisterExperience/{idCandidate}")]
        [HttpGet]
        public PartialViewResult RegisterExperience(int idCandidate)
        {
            var oCandidateExperienceVM = new CandidateExperienceViewModel { IdCandidate = idCandidate };
            return PartialView("_CandidateExperienceModal", oCandidateExperienceVM);
        }

        [Route("RegisterExperience")]
        [HttpPost]
        public PartialViewResult RegisterExperience(CandidateExperienceViewModel candidateExperience)
        {
            try
            {
                CandidateExperienceHelper.AddCandidateExperience(_hostWebApi, candidateExperience);
                var lstExperiences = CandidateExperienceHelper.ListByCandidate(_hostWebApi, candidateExperience.IdCandidate);

                return PartialView("_CandidateExperienceRowTable", lstExperiences);
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
                return PartialView("_Erro");
            }
        }

        [Route("EditExperience/{idCandidateExperience}")]
        [HttpGet]
        public PartialViewResult EditExperience(int idCandidateExperience)
        {
            try
            {
                var oCandidateExperienceVM = CandidateExperienceHelper.GetCandidateExperience(_hostWebApi, idCandidateExperience);
                return PartialView("_CandidateExperienceModal", oCandidateExperienceVM);
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
                return PartialView("_Erro");
            }
        }

        [Route("EditExperience")]
        [HttpPost]
        public PartialViewResult EditExperience(CandidateExperienceViewModel candidateExperience)
        {
            try
            {
                CandidateExperienceHelper.UpdateCandidateExperience(_hostWebApi, candidateExperience);
                var lstExperiences = CandidateExperienceHelper.ListByCandidate(_hostWebApi, candidateExperience.IdCandidate);

                return PartialView("_CandidateExperienceRowTable", lstExperiences);
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
                return PartialView("_Erro");
            }
        }

        [Route("DeleteExperience/{idCandidateExperience}")]
        [HttpPost]
        public JsonResult DeleteExperience(int idCandidateExperience)
        {
            try
            {
                CandidateExperienceHelper.DeleteCandidateExperience(_hostWebApi, idCandidateExperience);
                return Json(new { FlSucesso = true, Mensagem = "Record deleted successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = true, Mensagem = ex.Message });
            }
        }

        #endregion

    }
}
