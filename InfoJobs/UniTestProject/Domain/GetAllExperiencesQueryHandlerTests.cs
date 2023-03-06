using AutoMapper;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.DTO;
using InfoJobs.Query;
using MediatR;
using Moq;

namespace UnitTestProject
{
    public class GetAllExperiencesQueryHandlerTests
    {
        [Fact]
        public async Task Handle_Returns_IEnumerableOfExperienceDTOs()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(x => x.Experiences.GetAll());
            var mockMapper = new Mock<IMapper>();

            var mediator = new Mock<IMediator>();
            //Act
            var handler = new GetAllExperiencesQueryHandler(mockRepo.Object, mockMapper.Object);
            var model = new List<ExperienceDTO>();
            var request = new GetAllExperiencesQuery();

            var result = await handler.Handle(new GetAllExperiencesQuery(), CancellationToken.None);

            //Assert
            Assert.IsAssignableFrom<IEnumerable<ExperienceDTO>>(result);
            Assert.Equal(model, result);
        }
    }
}
