using System;

namespace RockPaperScissors.Models
{
  public class RandomGenerator
  {
    private Random random = new Random();

    public virtual int GetNumber(int maxValue)
    {
      return random.Next(maxValue);
    }
  }
}