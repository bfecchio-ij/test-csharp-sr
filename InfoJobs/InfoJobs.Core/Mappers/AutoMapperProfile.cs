using AutoMapper;
using InfoJobs.Domain.Data.Entities;
using InfoJobs.Domain.DTO;

namespace InfoJobs.Core.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Candidate, CandidateDTO>();
            CreateMap<Experience, ExperienceDTO>();
            CreateMap<CreateCandidateDTO, Candidate>();
            CreateMap<UpdateCandidateDTO, Candidate>();
            CreateMap<CreateExperienceDTO, Experience>();
            CreateMap<UpdateExperienceDTO, Experience>();
        }
    }
}
