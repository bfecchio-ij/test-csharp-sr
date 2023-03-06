using AutoMapper;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.Data.Entities;
using InfoJobs.Domain.DTO;
using InfoJobs.Query;
using MediatR;
using Moq;

namespace UnitTestProject
{
    public class GetExperienceByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_Returns_ExperienceDTO()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            int id = 1;
            mockRepo.Setup(x => x.Experiences.Get(id)).Returns(new Experience() {  Id = 1, Company = "content", Job = "test", Description = "test", Salary = 1500, InsertDate = System.DateTime.Now, CandidateId = 1});
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<ExperienceDTO>(It.IsAny<Experience>())).Returns(new ExperienceDTO());

            var mediator = new Mock<IMediator>();
            //Act
            var handler = new GetExperienceByIdQueryHandler(mockRepo.Object, mockMapper.Object);
            var model = new ExperienceDTO();
            
            int experienceId = 1;
            var request = new GetExperienceByIdQuery(experienceId);
            var experience = await Task.FromResult(mockRepo.Object.Experiences.Get(request.ExperienceId));
            mockMapper.Object.Map<ExperienceDTO>(experience);
            var result = await handler.Handle(new GetExperienceByIdQuery(experience.Id), CancellationToken.None);

            //Assert
            Assert.IsAssignableFrom<ExperienceDTO>(result);
            Assert.Equal(model.Id, result.Id);
            Assert.Equal(model.Company, result.Company);
            Assert.Equal(model.Job, result.Job);
            Assert.Equal(model.Description, result.Description);
            Assert.Equal(model.Salary, result.Salary);
            Assert.Equal(model.BeginDate, result.BeginDate);
            Assert.Equal(model.EndDate, result.EndDate);
            Assert.Equal(model.InsertDate, result.InsertDate);
            Assert.Equal(model.ModifyDate, result.ModifyDate);

        }
    }
}
