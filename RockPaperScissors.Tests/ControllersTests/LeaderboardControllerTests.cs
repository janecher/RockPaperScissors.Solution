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

      var list = new List<PlayerInfo>(){new PlayerInfo{PlayerName = "Evgeniya", Score = 2}, new PlayerInfo{PlayerName = "Jane", Score = 1}};

      var listResult = objectResult.Value as List<PlayerInfo>;

      //Assert
      Assert.IsNotNull(objectResult);
      Assert.AreEqual(200, objectResult.StatusCode);
      Assert.AreEqual(2, listResult.Count);
      Assert.AreEqual("Evgeniya", listResult[0].PlayerName);
      Assert.AreEqual(2, listResult[0].Score);
      Assert.AreEqual("Jane", listResult[1].PlayerName);
      Assert.AreEqual(1, listResult[1].Score);
      
      randomTest.VerifyAll();
    }
  }
}