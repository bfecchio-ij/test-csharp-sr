using FluentValidation;
using InfoJobs.Command;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.Data.Entities;
using InfoJobs.Domain.DTO;
using MediatR;
using Moq;

namespace UnitTestProject
{
    public class UpdateCandidateCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Returns_Int()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(x => x.Candidates.Add(It.IsAny<Candidate>()));
            var mockValidator = new Mock<IValidator<UpdateCandidateDTO>>();


            var value = new FluentValidation.Results.ValidationResult();
            mockValidator.Setup(x => x.Validate(It.IsAny<UpdateCandidateDTO>())).Returns(value);

            var mediator = new Mock<IMediator>();
            //Act
            var handler = new UpdateCandidateCommandHandler(mockRepo.Object, mockValidator.Object);
            var model = new UpdateCandidateDTO() { Name = "Test", Surname = "Test", Email = "jc123@gmail.com", BirthDate = DateTime.Now };
            int id = 0;
            var request = new UpdateCandidateCommand(model, id);
            var requestModel = request.Model;

            var validModel = mockValidator.Object.Validate(model);
            var entity = new Candidate();
            mockRepo.Object.Candidates.Update(entity);

            var result = await handler.Handle(new UpdateCandidateCommand(requestModel, id), CancellationToken.None);

            //Assert
            Assert.IsType<int>(result);
            Assert.Equal(0, result);
        }
    }
}
