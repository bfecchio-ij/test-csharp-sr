using FluentValidation;
using InfoJobs.Command;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.Data.Entities;
using InfoJobs.Domain.DTO;
using MediatR;
using Moq;

namespace UnitTestProject
{
    public class UpdateExperienceCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Returns_Int()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(x => x.Experiences.Add(It.IsAny<Experience>()));
            var mockValidator = new Mock<IValidator<UpdateExperienceDTO>>();


            var value = new FluentValidation.Results.ValidationResult();
            mockValidator.Setup(x => x.Validate(It.IsAny<UpdateExperienceDTO>())).Returns(value);

            var mediator = new Mock<IMediator>();
            //Act
            var handler = new UpdateExperienceCommandHandler(mockRepo.Object, mockValidator.Object);
            var model = new UpdateExperienceDTO() { Company = "Test", Job = "TestName", Description = "TestName", Salary = 1500, CandidateId = 1 };
            int id = 0;
            var request = new UpdateExperienceCommand(model, id);
            var requestModel = request.Model;

            var validModel = mockValidator.Object.Validate(model);
            var entity = new Experience();
            mockRepo.Object.Experiences.Update(entity);

            var result = await handler.Handle(new UpdateExperienceCommand(requestModel, id), CancellationToken.None);

            //Assert
            Assert.IsType<int>(result);
            Assert.Equal(0, result);
        }
    }
}
