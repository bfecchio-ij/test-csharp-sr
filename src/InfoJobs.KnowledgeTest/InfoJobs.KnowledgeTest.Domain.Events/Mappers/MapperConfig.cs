using AutoMapper;
using InfoJobs.KnowledgeTest.Domain.Core.Entities.Curriculum;
using InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Commands;

namespace InfoJobs.KnowledgeTest.Domain.Events.Mappers
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
            cfg.CreateMap<AddCandidateCommand, CandidateEntity>().AfterMap((src, dest) =>
            {
                dest.InsertDate = DateTime.Now;
            });

            cfg.CreateMap<UpdateCandidateCommand, CandidateEntity>().AfterMap((src, dest) =>
            {
                dest.Id = src.IdCandidate;
                dest.ModifyDate = DateTime.Now;
            });

            cfg.CreateMap<AddCandidateExperienceCommand, CandidateExperienceEntity>().AfterMap((src, dest) =>
            {
                dest.InsertDate = DateTime.Now;
            });

            cfg.CreateMap<UpdateCandidateExperienceCommand, CandidateExperienceEntity>().AfterMap((src, dest) =>
            {
                dest.Id = src.IdCandidateExperience;
                dest.ModifyDate = DateTime.Now;
            });
        }
    }
}
