using InfoJobs.API.Controllers;
using InfoJobs.Command;
using InfoJobs.Core.Exceptions;
using InfoJobs.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTestProject
{
    public class ExperiencesControllerTests
    {
        [Fact]
        public async Task CandidateExperience_returns_ObjectResult()
        {
            var mediator = new Mock<IMediator>();
            var controller = new ExperienceController(mediator.Object);
            var model = new CreateExperienceDTO() { Company = "Test", Job = "Tester", Description = "teste teste teste", Salary = 1500, BeginDate = new DateTime(2022, 10, 01), CandidateId = 1 };
            var result = await controller.Candidate(model);
            var okResult = result as ObjectResult;
            Assert.IsType<ObjectResult>(result);
            Assert.NotNull(result);
            Assert.Equal(201, okResult?.StatusCode);
        }



        [Fact]
        public async Task Candidate_throws_exception_when_RequestBody_Invalid()
        {
            var mediator = new Mock<IMediator>();
            var controller = new ExperienceController(mediator.Object);
            var model = new CreateExperienceDTO() { Company = null, Job = null, Description = null, Salary = 0, CandidateId = 0 };
            var result = await controller.Candidate(model);
            _ = Assert.ThrowsAsync<InvalidRequestBodyException>(async () => await controller.Candidate(model));
        }

        [Fact]
        public async Task GetAll_returns_OkResult()
        {
            var mediator = new Mock<IMediator>();
            var controller = new ExperienceController(mediator.Object);
            var model = new List<ExperienceDTO>();
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
            var controller = new ExperienceController(mediator.Object);
            var model = new ExperienceDTO();
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
            var controller = new ExperienceController(mediator.Object);
            var result = await controller.GetById(1);
            _ = Assert.ThrowsAsync<EntityNotFoundException>(async () => await controller.GetById(1));
        }

        [Fact]
        public async Task Delete_Returns_ObjectResult()
        {
            var mediator = new Mock<IMediator>();
            var controller = new ExperienceController(mediator.Object);
            var model = new ExperienceDTO();
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
            var controller = new ExperienceController(mediator.Object);
            int id = 0;
            var result = await controller.Delete(id);
            _ = Assert.ThrowsAsync<InvalidRequestBodyException>(async () => await controller.Delete(id));
        }

        [Fact]
        public async Task Update_Returns_ObjectResult()
        {
            var mediator = new Mock<IMediator>();
            var controller = new ExperienceController(mediator.Object);
            var model = new UpdateExperienceDTO();
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
            var controller = new ExperienceController(mediator.Object);
            var model = new UpdateExperienceDTO() { Company = null, Job = null, Description = null, Salary = 0, CandidateId = 0 };
            int id = 1;
            var result = await controller.Update(model, id);
            _ = Assert.ThrowsAsync<InvalidRequestBodyException>(async () => await controller.Update(model, id));
        }
            
        [Fact]
        public void Candidate_SendsQueryWithTheCorrectData()
        {

            var model = new CreateExperienceDTO() { Company = "Test", Job = "Tester", Description = "teste teste teste", Salary = 1500, BeginDate = new DateTime(2022, 10, 01), CandidateId = 1 };
            var mediator = new Mock<IMediator>();
            var sut = new ExperienceController(mediator.Object);

            sut?.Candidate(model);

            mediator.Verify(x => x.Send(It.Is<CreateExperienceCommand>(y => y.Model.Company == model.Company), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(x => x.Send(It.Is<CreateExperienceCommand>(y => y.Model.Job == model.Job), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(x => x.Send(It.Is<CreateExperienceCommand>(y => y.Model.Description == model.Description), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(x => x.Send(It.Is<CreateExperienceCommand>(y => y.Model.Salary == model.Salary), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(x => x.Send(It.Is<CreateExperienceCommand>(y => y.Model.CandidateId == model.CandidateId), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}