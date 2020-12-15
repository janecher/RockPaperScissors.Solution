using System;
using System.Collections.Generic;

namespace RockPaperScissors.Models
{
  public class Player
  {
    public string Name {get; set;}
    private static Dictionary<string, int> _playersList = new Dictionary<string, int>();
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

    public static string GameResult(string play, string name)
    {
      string randomPlay = RandomPlay();
      if(play == randomPlay)
      {
        return "ties";
      }
      if(play == "rock" && randomPlay == "scissors" || play == "scissors" && randomPlay == "paper" || play == "paper" && randomPlay == "rock")
      {
        if(_playersList.ContainsKey(name))
        {
          _playersList[name]++;
        }
        else
        {
          _playersList.Add(name, 1);
        }
        return "wins";
      }
      return "loses";
    }

    public static Dictionary<string, int> GetPlayersList()
    {
      return _playersList;
    }
  }
}