using LinkedinTest.Model;
using System.Collections.Generic;

namespace LinkedinTest.Repositories
{
    public interface ICandidateRepository
    {
        public List<CandidateModel> GetCandidates();
    }
}
