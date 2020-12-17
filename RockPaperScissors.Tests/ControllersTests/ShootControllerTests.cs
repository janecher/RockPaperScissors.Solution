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
  public class ControllersTests : ControllerBase
  {
    [TestMethod]
    public void GetShoot_Ties_Ok()
    {
        // Arrange
        Mock<RandomGenerator> randomTest = new Mock<RandomGenerator>(MockBehavior.Strict);
        randomTest.Setup(h => h.GetNumber(It.Is<int>(t => t == 3)))
          .Returns(2);
        ShootController controller = new ShootController(randomTest.Object);

        // Act
        var actionResult = controller.Get("scissors", "Evgeniya");
        var objectResult = actionResult.Result as ObjectResult;

        //Assert
        Assert.IsNotNull(objectResult);
        Assert.AreEqual(200, objectResult.StatusCode);
        Assert.AreEqual("Player Evgeniya ties the round", objectResult.Value);
    }

    [TestMethod]
    public void GetShoot_Wins_Ok()
    {
        // Arrange
        Mock<RandomGenerator> randomTest = new Mock<RandomGenerator>(MockBehavior.Strict);
        randomTest.Setup(h => h.GetNumber(It.Is<int>(t => t == 3)))
          .Returns(2);
        ShootController controller = new ShootController(randomTest.Object);

        // Act
        var actionResult = controller.Get("rock", "Evgeniya");
        var objectResult = actionResult.Result as ObjectResult;

        //Assert
        Assert.IsNotNull(objectResult);
        Assert.AreEqual(200, objectResult.StatusCode);
        Assert.AreEqual("Player Evgeniya wins the round", objectResult.Value);
    }

    [TestMethod]
    public void GetShoot_EmptyPlay_BadRequest()
    {
        // Arrange
        Mock<RandomGenerator> randomTest = new Mock<RandomGenerator>(MockBehavior.Strict);
        randomTest.Setup(h => h.GetNumber(It.Is<int>(t => t == 3)))
          .Returns(2);
        ShootController controller = new ShootController(randomTest.Object);

        // Act
        var actionResult = controller.Get("", "Evgeniya");
        var objectResult = actionResult.Result as ObjectResult;

        var errorMessage = objectResult.Value as ErrorMessage;

        //Assert
        Assert.IsNotNull(objectResult);
        Assert.AreEqual(400, objectResult.StatusCode);
        Assert.AreEqual("player_name and play parameters are required", errorMessage.Error);
    }

    [TestMethod]
    public void GetShoot_IncorrectPlay_BadRequest()
    {
        // Arrange
        Mock<RandomGenerator> randomTest = new Mock<RandomGenerator>(MockBehavior.Strict);
        randomTest.Setup(h => h.GetNumber(It.Is<int>(t => t == 3)))
          .Returns(2);
        ShootController controller = new ShootController(randomTest.Object);

        // Act
        var actionResult = controller.Get("play", "Evgeniya");
        var objectResult = actionResult.Result as ObjectResult;

        var errorMessage = objectResult.Value as ErrorMessage;

        //Assert
        Assert.IsNotNull(objectResult);
        Assert.AreEqual(400, objectResult.StatusCode);
        Assert.AreEqual("play parameter is invalid", errorMessage.Error);
    }
  }
}