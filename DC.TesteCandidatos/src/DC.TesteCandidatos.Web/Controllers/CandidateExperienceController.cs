using DC.TesteCandidatos.Domain.Commands;
using DC.TesteCandidatos.Domain.Entities;
using DC.TesteCandidatos.Domain.Interfaces;
using DC.TesteCandidatos.Domain.Queries;
using DC.TesteCandidatos.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DC.TesteCandidatos.Web.Controllers
{
    public class CandidateExperienceController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Candidates> _candidatesRepository;
        private readonly IRepository<CandidateExperiences> _experiencesRepository;

        public CandidateExperienceController(IMediator mediator, IRepository<Candidates> candiadtesRepository,
            IRepository<CandidateExperiences> experiencesRepository)
        {
            _mediator = mediator;
            _candidatesRepository = candiadtesRepository;
            _experiencesRepository = experiencesRepository;
        }

        public IActionResult InclueExperience(int? id)
        {
            try
            {
                var candidate = _mediator.Send(new CandidateSelectQuery() { Id = id.Value }).Result;

                if(candidate != null)
                {
                    var experiences = from item in _mediator.Send(new ExperiencesGetAllQuery()).Result
                                      where item.IdCandidate == candidate.IdCandidates
                                      select item;

                    CandidateExperienceIncludeViewModel model = new CandidateExperienceIncludeViewModel()
                    {
                        IdCandidate = candidate.IdCandidates,
                        Candidate = candidate,
                        Experiences = experiences.ToList(),
                        Fullname = String.Format($"{candidate.Name} {candidate.Surname}")
                    };

                    return View(model);
                }

                return Redirect($"/Candidates/EditCandidates/{id.Value}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult DetailsExperience(int? id, string historic, CandidateExperiencesDetailsViewModel? model)
        {
            try
            {
                if (!String.IsNullOrEmpty(model.ErrorMessage))
                {
                    return View(model);
                }

                var experience = _mediator.Send(new ExperiencesSelectQuery { IdExperience = id.Value }).Result;

                if (experience != null)
                {
                    var partialModel = new CandidateExperiencesDetailsViewModel
                    {
                        IdExperince = experience.IdCandidateExperiences,
                        IdCandidate = experience.IdCandidate,
                        Company = experience.Company,
                        Job = experience.Job,
                        Salary = experience.Salary,
                        Description = experience.Description,
                        BeginDate = experience.BeginDate,
                        EndDate = experience.EndDate,
                        HistoricBack = String.IsNullOrEmpty(historic) ? "Include" : historic
                    };
                    return View(partialModel);
                }
                else
                    return Redirect($"InclueExperience/{id.Value}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult ResetExperiences(CandidateExperienceIncludeViewModel model)
        {
            return Redirect($"InclueExperience/{model.IdCandidate}");
        }

        public IActionResult ResetDetailExperience(CandidateExperiencesDetailsViewModel model)
        {
            return Redirect($"DetailsExperience/{model.IdExperince}");
        }

        public IActionResult SaveExperience(CandidateExperienceIncludeViewModel model)
        {
            model.NewExperience.IdCandidate = model.IdCandidate;

            var command = new ExperienceCreateCommand();
            command.IdCandidatos = model.IdCandidate;
            command.Company = model.NewExperience.Company;
            command.Job = model.NewExperience.Job;
            command.Salary = model.NewExperience.Salary;
            command.Description = model.NewExperience.Description;
            command.BeginDate = model.NewExperience.BeginDate;
            command.EndDate = model.NewExperience.EndDate;

            var result = _mediator.Send(command).Result;

            return Redirect($"InclueExperience/{model.IdCandidate}");
        }

        public IActionResult DeleteExperience(CandidateExperienceIncludeViewModel model)
        {
            try
            {
                var response = _mediator.Send(new ExperienceDeleteCommand { IdExperience = model.IdExperince }).Result;
                return Redirect($"InclueExperience/{model.IdCandidate}");
            }
            catch(Exception ex)
            {
                return RedirectToAction(nameof(DeleteExperience), new CandidateExperiencesDetailsViewModel { ErrorMessage = ex.Message});
            }
        }

        public IActionResult SaveEditExperience(CandidateExperiencesDetailsViewModel model)
        {
            try
            {
                var command = new ExperienceUpdateCommand
                {
                    IdExperience = model.IdExperince,
                    Company = model.Company,
                    Job = model.Job,
                    Salary = model.Salary,
                    Description = model.Description,
                    BeginDate = model.BeginDate,
                    EndDate = model.EndDate
                };

                var result = _mediator.Send(command);

                return Redirect($"InclueExperience/{model.IdCandidate}");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
