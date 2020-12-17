using RockPaperScissors.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors.Tests
{
  [TestClass]
  public class PlayerTests
  {
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "player_name and play parameters are required")]
    public void PlayGame_EmptyParameters_ArgumentException()
    {
      Player player = new Player(new RandomGenerator());
      player.PlayGame("", "");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "play parameter is invalid")]
    public void PlayGame_InvalidPlay_ArgumentException()
    {
      Player player = new Player(new RandomGenerator());
      player.PlayGame("roccs", "Evgeniya");
    }

    [TestMethod]
    public void PlayGame_BothScissors_Ties()
    {
      Mock<RandomGenerator> randomTest = new Mock<RandomGenerator>(MockBehavior.Strict);
      randomTest.Setup(h => h.GetNumber(It.Is<int>(t => t == 3)))
        .Returns(2);
      Player player = new Player(randomTest.Object);
      Assert.AreEqual("ties", player.PlayGame("scissors", "Evgeniya"));

      randomTest.VerifyAll();
    }
    
    [TestMethod]
    public void PlayGame_RockScissors_Wins()
    {
      Mock<RandomGenerator> randomTest = new Mock<RandomGenerator>(MockBehavior.Strict);
      randomTest.Setup(h => h.GetNumber(It.Is<int>(t => t == 3)))
        .Returns(2);
      Player player = new Player(randomTest.Object);
      Assert.AreEqual("wins", player.PlayGame("rock", "Evgeniya"));

      randomTest.VerifyAll();
    }

    [TestMethod]
    public void PlayGame_PaperScissors_Loses()
    {
      Mock<RandomGenerator> randomTest = new Mock<RandomGenerator>(MockBehavior.Strict);
      randomTest.Setup(h => h.GetNumber(It.Is<int>(t => t == 3)))
        .Returns(2);
      Player player = new Player(randomTest.Object);
      Assert.AreEqual("loses", player.PlayGame("paper", "Evgeniya"));

      randomTest.VerifyAll();
    }
  }
}