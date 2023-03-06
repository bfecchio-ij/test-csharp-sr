using FluentValidation;
using InfoJobs.Command;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.Data.Entities;
using InfoJobs.Domain.DTO;
using MediatR;
using Moq;

namespace UnitTestProject
{
    public class CreateExperienceCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Returns_Int()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(x => x.Experiences.Add(It.IsAny<Experience>()));
            var mockValidator = new Mock<IValidator<CreateExperienceDTO>>();


            var value = new FluentValidation.Results.ValidationResult();
            mockValidator.Setup(x => x.Validate(It.IsAny<CreateExperienceDTO>())).Returns(value);

            var mediator = new Mock<IMediator>();
            //Act
            var handler = new CreateExperienceCommandHandler(mockRepo.Object, mockValidator.Object);
            var model = new CreateExperienceDTO() { Company = "Test", Job = "TestName", Description = "TestName", Salary = 1500, CandidateId = 1 };
            var request = new CreateExperienceCommand(model);
            var requestModel = request.Model;
           
            var validModel = mockValidator.Object.Validate(model);
            var entity = new Experience();
            mockRepo.Object.Experiences.Add(entity);

            var result = await handler.Handle(new CreateExperienceCommand(requestModel), CancellationToken.None);

            //Assert
            Assert.IsType<int>(result);
            Assert.Equal(0, result);
        }
    }
}
