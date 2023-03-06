using AutoMapper;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.DTO;
using InfoJobs.Query;
using MediatR;
using Moq;

namespace UnitTestProject
{
    public class GetAllCandidatesQueryHandlerTests
    {
        [Fact]
        public async Task Handle_Returns_IEnumerableOfCandidateDTOs()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(x => x.Candidates.GetAll());
            var mockMapper = new Mock<IMapper>();

            var mediator = new Mock<IMediator>();
            //Act
            var handler = new GetAllCandidatesQueryHandler(mockRepo.Object, mockMapper.Object);
            var model = new List<CandidateDTO>();
            var request = new GetAllCandidatesQuery();

            var result = await handler.Handle(new GetAllCandidatesQuery(), CancellationToken.None);

            //Assert
            Assert.IsAssignableFrom<IEnumerable<CandidateDTO>>(result);
            Assert.Equal(model, result);
        }
    }
}
