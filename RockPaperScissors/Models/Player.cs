using System;

namespace RockPaperScissors.Models
{
  public class Player
  {
    public string Name {get; set;}
    public Player(string name)
    {
      Name = name;
    }
    public static string[] plays = new string[3]{"rock", "paper", "scissors"};

    public static string RandomPlay()
    {
      Random rand = new Random();
      int randomPlay = rand.Next(3); 
      return plays[randomPlay];
    }
  }
}