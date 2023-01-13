using AutoMapper;
using InfoJobs.KnowledgeTest.Application.Curriculum.ViewModels;
using InfoJobs.KnowledgeTest.Domain.Core.Entities.Curriculum;

namespace InfoJobs.KnowledgeTest.Application.Mappers
{
    public class MapperConfig
    {
        public static IMapper RegisterMappers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                Curriculum(cfg);
            });

            return config.CreateMapper();
        }

        private static void Curriculum(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CandidateViewModel, CandidateEntity>().ReverseMap();
            cfg.CreateMap<CandidateExperienceViewModel, CandidateExperienceEntity>().ReverseMap();
        }
    }
}