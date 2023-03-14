using LinkedinTest.Data;
using LinkedinTest.Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinkedinTest.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        public List<CandidateModel> GetCandidates()
        {
            using(var context = new ApplicationDbContext())
            {
                return context.Candidates.ToList();
            }
        }
    }
}
