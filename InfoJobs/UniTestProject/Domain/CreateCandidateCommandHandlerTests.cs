using FluentValidation;
using InfoJobs.Command;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.Data.Entities;
using InfoJobs.Domain.DTO;
using MediatR;
using Moq;

namespace UnitTestProject
{
    public class CreateCandidateCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Returns_Int()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(x => x.Candidates.Add(It.IsAny<Candidate>()));
            var mockValidator = new Mock<IValidator<CreateCandidateDTO>>();


            var value = new FluentValidation.Results.ValidationResult();
            mockValidator.Setup(x => x.Validate(It.IsAny<CreateCandidateDTO>())).Returns(value);

            var mediator = new Mock<IMediator>();
            //Act
            var handler = new CreateCandidateCommandHandler(mockRepo.Object, mockValidator.Object);
            var model = new CreateCandidateDTO() { Name = "Test", Surname = "Test", BirthDate = new DateTime(1989, 01, 30), Email = "jc123@gmail.com" };
            var request = new CreateCandidateCommand(model);
            var requestModel = request.Model;

            var validModel = mockValidator.Object.Validate(model);
            var entity = new Candidate();
            mockRepo.Object.Candidates.Add(entity);

            var result = await handler.Handle(new CreateCandidateCommand(requestModel), CancellationToken.None);

            //Assert
            Assert.IsType<int>(result);
            Assert.Equal(0, result);
        }
    }
}
