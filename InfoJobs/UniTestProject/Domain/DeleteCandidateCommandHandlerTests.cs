using InfoJobs.Command;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.Data.Entities;
using MediatR;
using Moq;

namespace UnitTestProject
{
    public class DeleteCandidateCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Returns_Int()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(x => x.Candidates.Delete(It.IsAny<Candidate>()));

            var mediator = new Mock<IMediator>();
            //Act
            var handler = new DeleteCandidateCommandHandler(mockRepo.Object);
            int id = 0;

            mockRepo.Object.Candidates.Delete(id);

            var result = await handler.Handle(new DeleteCandidateCommand(id), CancellationToken.None);

            //Assert
            Assert.IsType<int>(result);
            Assert.Equal(0, result);
        }
    }
}
