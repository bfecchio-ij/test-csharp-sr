using LinkedinTest.Model;
using LinkedinTest.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkedinTest.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        GenericRepository<CandidateModel> candidateRepo;

        public UnitOfWork()
        {
            CreateFakeData();
        }

        public void CreateFakeData()
        {
            using(var context = new ApplicationDbContext())
            {
                var candidates = new List<CandidateModel>()
                {
                    new CandidateModel { Name = "test1", Birthdate = DateTime.Now, Email = "test1@gmail.com" },
                    new CandidateModel { Name = "test2", Birthdate = DateTime.Now, Email = "test2@gmail.com" },
                    new CandidateModel { Name = "test3", Birthdate = DateTime.Now, Email = "test3@gmail.com" },
                    new CandidateModel { Name = "test4", Birthdate = DateTime.Now, Email = "test4@gmail.com" }
                };

                context.Candidates.AddRange(candidates);
                context.SaveChanges();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public GenericRepository<CandidateModel> CandidateRepo()
        {
            if(this.candidateRepo == null)
            {
                this.candidateRepo = new GenericRepository<CandidateModel>(dbContext);
            }
            return candidateRepo;
        }
    }
}
