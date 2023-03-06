using AutoMapper;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.Data.Entities;
using InfoJobs.Domain.DTO;
using InfoJobs.Query;
using MediatR;
using Moq;

namespace UnitTestProject
{
    public class GetCandidateByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_Returns_CandidateDTO()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            int id = 1;
            mockRepo.Setup(x => x.Candidates.GetByIdInclude(id)).Returns(new Candidate() { Id = 1, Name = "Test", Surname = "Test", Email = "jc123@gmail.com", BirthDate = DateTime.Now });
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<CandidateDTO>(It.IsAny<Candidate>())).Returns(new CandidateDTO());

            var mediator = new Mock<IMediator>();
            //Act
            var handler = new GetCandidateByIdQueryHandler(mockRepo.Object, mockMapper.Object);
            var model = new CandidateDTO();

            int candidateId = 1;
            var request = new GetCandidateByIdQuery(candidateId);
            var candidate = await Task.FromResult(mockRepo.Object.Candidates.GetByIdInclude(request.CandidateId));
            mockMapper.Object.Map<CandidateDTO>(candidate);
            var result = await handler.Handle(new GetCandidateByIdQuery(candidate.Id), CancellationToken.None);

            //Assert
            Assert.IsAssignableFrom<CandidateDTO>(result);
            Assert.Equal(model.Id, result.Id);
            Assert.Equal(model.Name, result.Name);
            Assert.Equal(model.Surname, result.Surname);
            Assert.Equal(model.BirthDate, result.BirthDate);
            Assert.Equal(model.Email, result.Email);
            Assert.Equal(model.InsertDate, result.InsertDate);
            Assert.Equal(model.ModifyDate, result.ModifyDate);

        }
    }
}
