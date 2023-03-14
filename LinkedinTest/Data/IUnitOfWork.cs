using LinkedinTest.Model;
using System.Threading.Tasks;

namespace LinkedinTest.Data
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChangesAsync();
        public GenericRepository<CandidateModel> CandidateRepo();
    }
}
