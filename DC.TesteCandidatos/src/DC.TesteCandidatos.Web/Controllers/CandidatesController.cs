using DC.TesteCandidatos.Domain.Commands;
using DC.TesteCandidatos.Domain.Entities;
using DC.TesteCandidatos.Domain.Interfaces;
using DC.TesteCandidatos.Domain.Queries;
using DC.TesteCandidatos.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DC.TesteCandidatos.Web.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Candidates> _candidatesRepository;
        private readonly IRepository<CandidateExperiences> _experiencesRepository;

        public CandidatesController(IMediator mediator, IRepository<Candidates> candiadtesRepository, IRepository<CandidateExperiences> experiencesRepository)
        {
            _mediator = mediator;
            _candidatesRepository = candiadtesRepository;
            _experiencesRepository = experiencesRepository;
        }
        #region PAGE LOAD
        public IActionResult ListarCandidates()
        {
            CandidatesListarViewModel model = new CandidatesListarViewModel();
            model.lstCandidadtes = _candidatesRepository.GetAll().Result.ToList();
            return View(model);
        }

        public IActionResult IncludeCandidates()
        {
            CandidatesIncludeViewModel model = new CandidatesIncludeViewModel();
            return View(model);
        }

        public IActionResult EditCandidates(int? id)
        {
            CandidatesEditViewModel model;
            try
            {
                var candidate = _candidatesRepository.Select(id.Value).Result;

                if (candidate != null)
                {
                    var experiences = from item in _mediator.Send(new ExperiencesGetAllQuery()).Result
                                      where item.IdCandidate == candidate.IdCandidates
                                      select item;

                    model = new CandidatesEditViewModel
                    {
                        Id = candidate.IdCandidates,
                        Name = candidate.Name,
                        LastName = candidate.Name,
                        Surname = candidate.Surname,
                        LastSurname = candidate.Surname,
                        BirthDate = candidate.Birthdate,
                        LastBirthDate = candidate.Birthdate,
                        Email = candidate.Email,
                        LastEmail = candidate.Email,
                        lstExperiences = experiences.ToList()
                    };
                }
                else
                    model = new CandidatesEditViewModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(model);
        }
        #endregion

        #region ACTIONS
        public IActionResult ResetCandidate(int? id)
        {
            if (id.HasValue)
            {
                var candidate = _candidatesRepository.Select(id.Value).Result;
                return View(nameof(EditCandidates), new CandidatesEditViewModel
                {
                    Name = candidate.Name,
                    Surname = candidate.Surname,
                    BirthDate = candidate.Birthdate,
                    Email = candidate.Email
                });
            }
            else
                return View(nameof(IncludeCandidates), new CandidatesIncludeViewModel());
        }
        
        public IActionResult CreateCandidate(CandidatesIncludeViewModel model)
        {
            var command = new CandidateCreateCommand
            {
                Name = model.Name,
                Surname = model.Surname,
                Birthdate = model.BirthDate,
                Email = model.Email
            };

            var candidate = from item in _candidatesRepository.GetAll().Result
                            where item.Email == command.Email
                            select item;

            if (candidate.Any())
            {
                model.ErrorMessage = String.Format($"Email arready exists in database");
                return View(nameof(IncludeCandidates), model);
            }
            else
            {
                var commandoResponse = _mediator.Send(command).Result;
                var newCandidate = from item in _candidatesRepository.GetAll().Result
                                   where item.Email == command.Email
                                   select item;

                return Redirect(String.Format($"/CandidateExperience/InclueExperience/{newCandidate.FirstOrDefault().IdCandidates}"));
            }
        }

        public IActionResult SaveEditCandidate(CandidatesEditViewModel model, int? id)
        {
            try
            {
                var command = new CandidateUpdateCommand
                {
                    Id = id.Value,
                    Name = model.Name,
                    Surname = model.Surname,
                    Birthdate = model.BirthDate,
                    Email = model.Email
                };

                var queryCommand = new CandidateSelectQuery()
                {
                    Id = id.Value
                };

                var candidate = _mediator.Send(queryCommand).Result;
                if (candidate != null)
                {
                    if (!model.LastEmail.Equals(model.Email))
                    {
                        var emailRegistry = from item in _candidatesRepository.GetAll().Result
                                            where item.Email == command.Email
                                            select item;

                        if (emailRegistry.Any())
                        {
                            model.ErrorMessage = String.Format($"Email arready exists in database");
                            return View(nameof(EditCandidates), model);
                        }
                    }

                    _mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    model.ErrorMessage = String.Format($"Candidate not found in DB");
                    return View(nameof(EditCandidates), model);
                }
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                return View(nameof(EditCandidates), model);
            }
        }

        public IActionResult DeleteCandidate(int? id)
        {
            try
            {
                var command = new CandidateDeleteCommand()
                {
                    IdCandidate = id.Value
                };

                var result = _mediator.Send(command).Result;

                return RedirectToAction(nameof(ListarCandidates));
            }
            catch(Exception ex)
            {
                return View(nameof(IncludeCandidates), new CandidatesIncludeViewModel { ErrorMessage = ex.Message });
            }
        }
        #endregion
    }
}
