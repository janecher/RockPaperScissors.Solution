using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors.Models
{
  public class Player
  {
    private const string rock = "rock";
    private const string paper = "paper";
    private const string scissors = "scissors";
    private const string ties = "ties";
    private const string wins = "wins";
    private const string loses = "loses";
    private string[] plays = new string[3]{rock, paper, scissors};
    private static Dictionary<string, int> _playersList = new Dictionary<string, int>();

    public RandomGenerator RandomPlay {get; set;}

    public Player(RandomGenerator rand)
    {
      RandomPlay = rand;
    }

    public string PlayGame(string play, string player_name)
    {
      if(String.IsNullOrEmpty(play) || String.IsNullOrEmpty(player_name))
      {
        throw new ArgumentException("player_name and play parameters are required");
      }
      if(Array.IndexOf(plays, play) == -1)
      {
        throw new ArgumentException("play parameter is invalid");
      }

      string randomPlay = plays[RandomPlay.GetNumber(plays.Length)];

      if(play == randomPlay)
      {
        return ties;
      }
      else if(play == rock && randomPlay == scissors ||
              play == scissors && randomPlay == paper ||
              play == paper && randomPlay == rock)
      {
        if(_playersList.ContainsKey(player_name))
        {
          _playersList[player_name]++;
        }
        else
        {
          _playersList.Add(player_name, 1);
        }
        return wins;
      }
      else
      {
        return loses;
      }
    }

    public static List<PlayerInfo> GetPlayersList()
    {
      return _playersList.OrderByDescending(key => key.Value).Select(playerInfo => new PlayerInfo { PlayerName = playerInfo.Key, Score = playerInfo.Value}).ToList();
    }
  }
}