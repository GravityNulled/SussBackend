using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Suss.Api.Controllers;
using Suss.Application;
using Suss.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suss.UnitTests.Controllers
{
    public class CampaignControllerTests
    {
        private readonly Mock<ICampaignService> _campaignService;
        private readonly IFixture _fixture;
        private readonly CampaignController _Campaigncontroller;
        public CampaignControllerTests()
        {
            _fixture = new Fixture();
            _campaignService = _fixture.Freeze<Mock<ICampaignService>>();
            _Campaigncontroller = new CampaignController(_campaignService.Object);
        }

        [Fact]
        public void Get_Campaign_Returns_OkResult_Response()
        {
            // Arrange
            var campaigns = _fixture.CreateMany<Campaign>(10);
            _campaignService.Setup(x => x.GetAll(1,3)).Returns(campaigns);

            // Act
            var result = _Campaigncontroller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetByID_Campaign_Returns_RightItem()
        {
            //Arrange
            var campaign = _fixture.Create<Campaign>(); // Create an object
            var id = _fixture.Create<int>(); // Create an Id
            _campaignService.Setup(x => x.GetById(id)).Returns(campaign); // Return the created object

            //Act
            var result = _Campaigncontroller.GetById(id);
            var resultType = result as OkObjectResult;
            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(resultType);
        }

    }
}
