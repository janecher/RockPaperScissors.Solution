# Rock Paper Scissors API

#### C# .Net Core Web API Application, 12/15/2020

#### By **Evgeniya Chernaya**

## Description

This Web API application makes a request to play a Rock-Paper-Scissors game and a request to show the leader board.

## Setup/Installation Requirements

* Install .Net Core 2.2 SDK //

In your browser, navigate to https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.2.106-macos-x64-installer for Mac or https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.2.203-windows-x64-installer for Windows and click the link "click here to download manually" if the download for .NET Core 2.2 SDK does not start automatically. //

Double-click the downloaded .NET Core 2.2 SDK file and run the installer. //

* In the terminal navigate to the directory where you want to clone the repo and enter the command: 
git clone https://github.com/janecher/RockPaperScissors.Solution.git

* In the terminal navigate to the directory RockPaperScissors.Solution

* To run the application, navigate to RockPaperScissors directory, and enter the command "dotnet restore", and then "dotnet run" in the terminal.

* To test the application, navigate to RockPaperScissors.Tests directory, and enter the command "dotnet restore", and then "dotnet test" in the terminal.

## API documentation

* Install Postman on your computer 

* Explore API endpoint in the Postman

#### HTTP Requests

* Base URL: http://localhost:5000
 
* GET /api/shoot - takes a query parameter 'play' that accept 'rock', 'paper' or 'scissors' values, and a query
parameter 'player_name' that takes the player's name. The endpoint return 200 OK with a string in the body that says <Player Name> wins/loses/ties the round

* GET /api/leaderboard - returns a JSON array of objects, with each object containing the name of the player and the number of rounds won. This list sorted descending by number of rounds won.

#### Example of search query

http://localhost:5000/api/shoot/?player_name=Evgeniya&play=rock

http://localhost:5000/api/leaderboard

#### Sample response

"Player Evgeniya ties the round"

[
  {
    "PlayerName": "Alina",
    "Score": 5
  },
  {
    "PlayerName": "Nikita",
    "Score": 3
  },
  {
    "PlayerName": "Evgeniya",
    "Score": 2
  }
]

## Known Bugs

_No known bugs_

## Technologies Used

  * C# .Net Core Web API
  * Visual Studio Code

### License

_This software is licensed under the MIT license_

Copyright (c) 2020 **Evgeniya Chernaya**.