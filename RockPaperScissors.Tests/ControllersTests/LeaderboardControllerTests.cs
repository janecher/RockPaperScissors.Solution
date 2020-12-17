using RockPaperScissors.Models;
using RockPaperScissors.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RockPaperScissors.Tests
{
  [TestClass]
  public class LeaderboardControllerTests : ControllerBase
  {
    [TestMethod]
    public void GetLeaderboard_Ties_Ok()
    {
        // Arrange
        Mock<RandomGenerator> randomTest = new Mock<RandomGenerator>(MockBehavior.Strict);
        randomTest.Setup(h => h.GetNumber(It.Is<int>(t => t == 3)))
          .Returns(2);
        ShootController controller = new ShootController(randomTest.Object);
        controller.Get("rock", "Jane");
        controller.Get("rock", "Evgeniya");
        controller.Get("rock", "Evgeniya");
        controller.Get("scissors", "Jane");
        controller.Get("paper", "Evgeniya");

        LeaderboardController leadController = new LeaderboardController();
        // Act
        var actionResult = leadController.Get();
        var objectResult = actionResult.Result as ObjectResult;

        var listResult = new List<PlayerInfo>(){new PlayerInfo{PlayerName = "Evgeniya", Score = 2}, new PlayerInfo{PlayerName = "Jane", Score = 1}};

        //Assert
        Assert.IsNotNull(objectResult);
        Assert.AreEqual(200, objectResult.StatusCode);
        Assert.AreEqual(JsonConvert.SerializeObject(listResult, Formatting.Indented), objectResult.Value);
    }
  }
}