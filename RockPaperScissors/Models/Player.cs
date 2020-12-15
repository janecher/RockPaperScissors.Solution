using System;
using System.Collections.Generic;

namespace RockPaperScissors.Models
{
  public class Player
  {
    private static Dictionary<string, int> _playersList = new Dictionary<string, int>();
    private static string[] plays = new string[3]{"rock", "paper", "scissors"};

    private static string RandomPlay()
    {
      Random rand = new Random();
      int randomPlay = rand.Next(3); 
      return plays[randomPlay];
    }
    
    public static string PlayGame(string play, string player_name)
    {
      if(String.IsNullOrEmpty(player_name) || String.IsNullOrEmpty(play))
      {
        throw new ArgumentException("player_name and play parameters are required");
      }
      if(Array.IndexOf(plays, play) == -1)
      {
        throw new ArgumentException("play parameter is invalid");
      }
      string randomPlay = RandomPlay();
      if(play == randomPlay)
      {
        return "ties";
      }
      if(play == "rock" && randomPlay == "scissors" ||
         play == "scissors" && randomPlay == "paper" ||
         play == "paper" && randomPlay == "rock")
      {
        if(_playersList.ContainsKey(player_name))
        {
          _playersList[player_name]++;
        }
        else
        {
          _playersList.Add(player_name, 1);
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