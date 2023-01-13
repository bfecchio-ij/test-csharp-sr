using InfoJobs.KnowledgeTest.Infra.Data.Contexts;
using InfoJobs.KnowledgeTest.Domain.Core.Entities.Curriculum;
using InfoJobs.KnowledgeTest.Domain.Core.Repositories.Curriculum;

namespace InfoJobs.KnowledgeTest.Infra.Data.Repositories.Curriculum.Commands
{
    public sealed class CandidateExperienceCommandRepository : RepositoryCommandBase<CandidateExperienceEntity, CurriculumContext>, ICandidateExperienceCommandRepository
    {
        public CandidateExperienceCommandRepository(CurriculumContext context) : base(context)
        {
        }

        public override void Update(CandidateExperienceEntity obj)
        {
            base.Update(obj);
            _context.Entry(obj).Property(p => p.InsertDate).IsModified = false;
        }
    }
}