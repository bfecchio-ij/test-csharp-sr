using InfoJobs.Command;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.Data.Entities;
using MediatR;
using Moq;

namespace UnitTestProject
{
    public class DeleteExperienceCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Returns_Int()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(x => x.Experiences.Delete(It.IsAny<Experience>()));

            var mediator = new Mock<IMediator>();
            //Act
            var handler = new DeleteExperienceCommandHandler(mockRepo.Object);
            int id = 0;
            
            mockRepo.Object.Experiences.Delete(id);

            var result = await handler.Handle(new DeleteExperienceCommand(id), CancellationToken.None);

            //Assert
            Assert.IsType<int>(result);
            Assert.Equal(0, result);
        }
    }
}
