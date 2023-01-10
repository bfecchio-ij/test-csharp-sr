using InfoJobsPoc.Application.Interfaces.ICommand;
using InfoJobsPoc.Application.Querys;
using InfoJobsPoc.Core.Entities;

namespace InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandResponse
{
    public class ExperienceResponse : ResultNormalized<ExperienceModelQuery>, IResponseCommandBase<ExperienceModelQuery>
    {
        public static ExperienceModelQuery parse(Experience? experience)
        {
            return new ExperienceModelQuery()
            {
                Job=experience?.Job ?? ""   ,
                Salary=experience?.Salary ?? 0  ,
                BeginDate=experience?.BeginDate??new DateTime(1000, 1, 1),
                Company = experience?.Company??"",
                Description=experience?.Description??"",
                EndDate=experience?.EndDate,
                Id=experience?.Id??0,
                IdCandidate=experience?.IdCandidate??0,
                InsertDate=experience?.InsertDate??new DateTime(1000,1,1),
                ModifyDate=experience?.ModifyDate,                
            };
        }
    }
}
