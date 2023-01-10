using InfoJobsPoc.Core.Entities;
using InfoJobsPoc.Core.Enums;
using InfoJobsPoc.Core.Interfaces.IRepository;
using InfoJobsPoc.Core.ServiceUseCases.CandidateUseCase;

namespace InfoJobsPoc.UnitTest.Domain.ServicesCasesTest
{
    public class ServiceCandidateCaseTest
    {
        [Fact]
        public void ServiceCandidate_Add_ExpectInvalidStatus()
        {   //mock
            var db = new List<Candidate>();
            var service = new ServiceCandidate(new FakeRepositoryW(db));
            var candidate = new Candidate()
            {
            };
            //test

            var notification = service.Add(candidate);
            Assert.NotNull(notification);
            Assert.Equal(notification.KeyPattern, typeof(ServiceCandidate).Name + "." + Enum.GetName(typeof(UseCaseEnums), UseCaseEnums.AddCandidate));
            var ret = notification.Messages.Where(item => item.Status == StatusEnum.Invalid && item.Key.Contains(typeof(ServiceCandidate).Name)).ToList();
            Assert.NotNull(ret);
        }
        [Fact]
        public void ServiceCandidate_Add_ExpectSuccessStatus()
        {   //mock
            var db = new List<Candidate>();
            var service = new ServiceCandidate(new FakeRepositoryW(db));
            var candidate = new Candidate()
            {
                Birthdate = new DateTime(1994, 07, 21),
                Email = "loribao@hotmail.com",
                InsertDate = DateTime.Now,
                Name = "Loribao",
                Surname = "Sanjinez"
            };
            //test

            var notification = service.Add(candidate);
            Assert.NotNull(notification);
            Assert.Equal(notification.KeyPattern, typeof(ServiceCandidate).Name + "." + Enum.GetName(typeof(UseCaseEnums), UseCaseEnums.AddCandidate));
            var ret = notification.Messages.Where(item => item.Status == StatusEnum.Ok && item.Key.Contains(typeof(ServiceCandidate).Name)).ToList();
            Assert.NotNull(ret);
            var candidateInsert = db.Where(x => x.Email == "loribao@hotmail.com").ToList();
            Assert.Equal(1, candidateInsert?.Count());
        }
        [Fact]
        public void ServiceCandidate_Update_ExpectSuccessStatus_ExpectEmailAndIdAndIsertdateNoChange()
        {
            var insertDate = DateTime.Now;

            //mock
            var db = new List<Candidate>();
            var service = new ServiceCandidate(new FakeRepositoryW(db));
            var candidate = new Candidate()
            {
                Id = 1,
                Birthdate = new DateTime(1994, 07, 21),
                Email = "loribao@hotmail.com",
                InsertDate = DateTime.Now,
                Name = "Loribao",
                Surname = "Sanjinez"
            };
            service.Add(candidate);
            var candidateUpdate = new Candidate()
            {
                Id = 1,
                Birthdate = new DateTime(1994, 07, 21),
                Email = "updateloribao@hotmail.com",
                InsertDate = insertDate,
                Name = "LoribaoUpdate",
                Surname = "SanjinezUpdate"
            };
            var notification = service.Update(candidateUpdate);

            //Assert            
            Assert.NotNull(notification);


            Assert.Equal(notification.KeyPattern, typeof(ServiceCandidate).Name + "." + Enum.GetName(typeof(UseCaseEnums), UseCaseEnums.UpdateCandidate));
            var ret = notification.Messages.Where(item => item.Status == StatusEnum.Ok && item.Key.Contains(typeof(ServiceCandidate).Name)).ToList();
            Assert.Equal(1, ret?.Count);
            var candidateInsert = db.Where(x => x.Email == "loribao@hotmail.com").ToList();
            Assert.Equal(1, candidateInsert?.Count());
            Assert.Equal(1, candidateInsert?.First().Id);
            Assert.Equal("LoribaoUpdate", candidateInsert?.First().Name);
        }
        [Fact]
        public void ServiceCandidate_Update_modifi_ExpectError()
        {
            var insertDate = DateTime.Now;

            //mock
            var db = new List<Candidate>();
            var service = new ServiceCandidate(new FakeRepositoryW(db));
            var candidate = new Candidate()
            {
                Id = 1,
                Birthdate = new DateTime(1994, 07, 21),
                Email = "loribao@hotmail.com",
                InsertDate = DateTime.Now,
                Name = "Loribao",
                Surname = "Sanjinez"
            };
            service.Add(candidate);
            var candidateUpdate = new Candidate()
            {
                Id = 1,
                Birthdate = new DateTime(1994, 07, 21),
                Email = "updateloribao@hotmail.com",
                InsertDate = insertDate,
                Name = "LoribaoUpdate",
                Surname = "SanjinezUpdate"
            };
            var notification = service.Update(candidateUpdate);

            //Assert            
            Assert.NotNull(notification);


            Assert.Equal(notification.KeyPattern, typeof(ServiceCandidate).Name + "." + Enum.GetName(typeof(UseCaseEnums), UseCaseEnums.UpdateCandidate));
            var ret = notification.Messages.Where(item => item.Status == StatusEnum.Ok && item.Key.Contains(typeof(ServiceCandidate).Name)).ToList();
            Assert.Equal(1, ret?.Count);
            var candidateInsert = db.Where(x => x.Email == "loribao@hotmail.com").ToList();
            Assert.Equal(1, candidateInsert?.Count());
            Assert.Equal(1, candidateInsert?.First().Id);
            Assert.Equal("LoribaoUpdate", candidateInsert?.First().Name);
        }
        internal class FakeRepositoryW : IRepositoryWriteBase<Candidate>
        {
            List<Candidate> repo;

            public FakeRepositoryW(List<Candidate> repo)
            {
                this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
            }

            public Candidate Add(Candidate item)
            {
                repo.Add(item);
                return item;
            }

            public void Dispose()
            {
                repo.Clear();
                throw new NotImplementedException();
            }

            public ValueTask DisposeAsync()
            {
                throw new NotImplementedException();
            }

            public Candidate Edit(Candidate item)
            {
                repo.Clear();
                repo.Add(item);
                return item;
            }

            public Candidate? Find(int id)
            {
                throw new NotImplementedException();
            }

            public IQueryable<Candidate> List()
            {
                return repo.AsQueryable();
            }

            public void Remove(Candidate item)
            {
                throw new NotImplementedException();
            }
        }
    }
}