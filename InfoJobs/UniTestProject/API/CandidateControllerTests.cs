using InfoJobs.API.Controllers;
using InfoJobs.Command;
using InfoJobs.Core.Exceptions;
using InfoJobs.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTestProject
{
    public class CandidateControllerTests
    {
        [Fact]
        public async Task AddCandidate_Success_Result()
        {
            var mediator = new Mock<IMediator>();
            int resultx = 0;
            mediator.Setup(a => a.Send(It.IsAny<CreateCandidateCommand>(), new CancellationToken()))
                .Returns(Task.FromResult(resultx));

            var CandidateController = new CandidateController(mediator.Object);

            var model = new CreateCandidateDTO() { Name = "Test", Email = "js123@gmail.com", Surname = "John", BirthDate = DateTime.Now };
            //Action
            var result = await CandidateController.Candidate(model);
            var okResult = result as ObjectResult;
            //Assert
            Assert.IsType<ObjectResult>(result);
            Assert.NotNull(result);
            Assert.Equal(201, okResult?.StatusCode);
        }

        [Fact]
        public async Task Candidate_throws_exception_when_RequestBody_Invalid()
        {
            var mediator = new Mock<IMediator>();
            var controller = new CandidateController(mediator.Object);
            var model = new CreateCandidateDTO() { Name = null, Email = null, Surname = null, BirthDate = DateTime.Now };
            var result = await controller.Candidate(model);
            _ = Assert.ThrowsAsync<InvalidRequestBodyException>(async () => await controller.Candidate(model));
        }

        [Fact]
        public async Task GetAll_returns_OkResult()
        {
            var mediator = new Mock<IMediator>();
            var controller = new CandidateController(mediator.Object);
            var model = new List<CandidateDTO>();
            var result = await controller.Get();
            var okResult = result as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult?.StatusCode);
        }

        [Fact]
        public async Task GetById_Returns_OkResult()
        {
            var mediator = new Mock<IMediator>();
            var controller = new CandidateController(mediator.Object);
            var model = new CandidateDTO();
            var result = await controller.GetById(1);
            var okResult = result as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult?.StatusCode);
        }

        [Fact]
        public async Task GetById_throws_exception_when_EntityNotFound()
        {
            var mediator = new Mock<IMediator>();
            var controller = new CandidateController(mediator.Object);
            var result = await controller.GetById(1);
            _ = Assert.ThrowsAsync<EntityNotFoundException>(async () => await controller.GetById(1));
        }

        [Fact]
        public async Task Delete_Returns_ObjectResult()
        {
            var mediator = new Mock<IMediator>();
            var controller = new CandidateController(mediator.Object);
            var model = new CandidateDTO();
            var result = await controller.Delete(1);
            var okResult = result as ObjectResult;
            Assert.IsType<ObjectResult>(result);
            Assert.NotNull(result);
            Assert.Equal(200, okResult?.StatusCode);
        }

        [Fact]
        public async Task Delete_throws_exception_when_RequestBody_Invalid()
        {
            var mediator = new Mock<IMediator>();
            var controller = new CandidateController(mediator.Object);
            int id = 0;
            var result = await controller.Delete(id);
            _ = Assert.ThrowsAsync<InvalidRequestBodyException>(async () => await controller.Delete(id));
        }

        [Fact]
        public async Task Update_Returns_ObjectResult()
        {
            var mediator = new Mock<IMediator>();
            var controller = new CandidateController(mediator.Object);
            var model = new UpdateCandidateDTO();
            int id = 1;
            var result = await controller.Update(model, id);
            var okResult = result as ObjectResult;
            Assert.IsType<ObjectResult>(result);
            Assert.NotNull(result);
            Assert.Equal(200, okResult?.StatusCode);
        }

        [Fact]
        public async Task Update_throws_exception_when_RequestBody_Invalid()
        {
            var mediator = new Mock<IMediator>();
            var controller = new CandidateController(mediator.Object);
            var model = new UpdateCandidateDTO() { Name = null, Email = null, Surname = null, BirthDate = DateTime.Now };
            int id = 1;
            var result = await controller.Update(model, id);
            _ = Assert.ThrowsAsync<InvalidRequestBodyException>(async () => await controller.Update(model, id));
        }

        [Fact]
        public void Candidate_SendsQueryWithTheCorrectData()
        {
            var model = new CreateCandidateDTO() { Name = "Test", Email = "js123@gmail.com", Surname = "John", BirthDate = DateTime.Now };
            var mediator = new Mock<IMediator>();
            var sut = new CandidateController(mediator.Object);

            sut?.Candidate(model);

            mediator.Verify(x => x.Send(It.Is<CreateCandidateCommand>(y => y.Model.Name == model.Name), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(x => x.Send(It.Is<CreateCandidateCommand>(y => y.Model.Surname == model.Surname), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(x => x.Send(It.Is<CreateCandidateCommand>(y => y.Model.Email == model.Email), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(x => x.Send(It.Is<CreateCandidateCommand>(y => y.Model.BirthDate == model.BirthDate), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
