using InfoJobsPoc.Application.Interfaces.ICommand;
using InfoJobsPoc.Application.Querys;
using InfoJobsPoc.Core.Entities;

namespace InfoJobsPoc.Application.CandidateCommands.CandidateCommandResponse
{
    public class CandidateReponse : ResultNormalized<CandidateModelQuery>, IResponseCommandBase<CandidateModelQuery>
    {
        public static CandidateModelQuery parse(Candidate? Data, Candidate _default)
        {
            if (Data == null) Data = _default;
            return new CandidateModelQuery()
            {

                Experiences = Data.Experiences?.Select(q => new ExperienceModelQuery()
                {
                    Company = q.Company,
                    Candidate = null,
                    BeginDate = q.BeginDate,
                    Description = q.Description,
                    Salary = q.Salary,
                    Id = q.Id,
                    InsertDate = q.InsertDate,
                    IdCandidate = q.IdCandidate,
                    ModifyDate = q.ModifyDate,
                    Job = q.Job,
                    EndDate = q.EndDate,
                }).ToList(),
                Id = Data.Id,
                Birthdate = Data?.Birthdate,
                Email = Data?.Email,
                ModifyDate = Data?.ModifyDate,
                InsertDate = Data.InsertDate,
                Name = Data.Name,
                Surname = Data.Surname
            };
        }
    }
}
