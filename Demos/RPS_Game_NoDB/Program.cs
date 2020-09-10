using System;
using System.Collections.Generic;
using System.Linq;

namespace RPS_Game_NoDB
{
    public enum Choice
    {
        Rock,     //0
        Paper,    //1 
        Scissors, //2
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            List<Game> games = new List<Game>();
            List<Round> rounds = new List<Round>();
            int choice;

            Player computer = new Player() { Name = "Computer" };//instantiate a Player and give a value to the Name all at once.
            players.Add(computer);
            int gameCounter = 1;

            do//game loop
            {
                System.Console.WriteLine($"\n\t\t2Rock Paper Scissors. This is game #{gameCounter++}");

                //get a choice from the user (play or quit)
                bool inputInt;
                do//prompt loop
                {
                    System.Console.WriteLine("Please choose 1 for Play, or 2 for Quit");
                    string input = Console.ReadLine();
                    inputInt = int.TryParse(input, out choice);
                } while (!inputInt || choice <= 0 || choice >= 3);//end of prompt loop

                if (choice == 2)//if the user chose 2, break out of the game.
                {
                    break;
                }
                //System.Console.WriteLine("made it out of the loop");

                //get the player name
                System.Console.WriteLine("What is your name?");
                string playerName = Console.ReadLine();
                Player p1 = new Player();//p1 is null here.

                // check the list of players to see if this payer is a returning player.
                foreach (Player item in players)
                {
                    if (item.Name == playerName)
                    {
                        p1 = item;
                        System.Console.WriteLine("You are a returning player");
                        break;//end the foreach loop
                    }
                }

                if (p1.Name == "null")//means the players name was not found above; add new player to list
                {
                    p1.Name = playerName;
                    players.Add(p1);
                }

                Game game = new Game();// create a game
                game.Player1 = p1;//
                game.Computer = computer;//

                Random rand = new Random();

                //play rounds till one player has 2 wins
                //assign the winner to the game and check that property to break out of the loop.
                while (game.winner.Name == "null")
                {
                    Round round = new Round();//declare a round for this iteration
                    round.game = game;// add the game to this round
                    round.player1 = p1;// add user (p1) to this round
                    round.Computer = computer;// add computer to this round

                    //get the choices for the 2 players
                    //insert the players choices directly into the round
                    round.p1Choice = (Choice)rand.Next(3);//this will give a random number starting at 0 to arg-1;
                    round.ComputerChoice = (Choice)rand.Next(3);

                    //check the choices to see who won.
                    if (round.p1Choice == round.ComputerChoice)
                    {
                        round.Outcome = 0; // it’s a tie . the default is 0 so this line is unnecessary.
                        System.Console.WriteLine("this round was a tie");
                    }
                    else if ((int)round.p1Choice == ((int)round.ComputerChoice + 1) % 3)
                    { //If users pick is one more than the computer’s, user wins
                        round.Outcome = 1;
                    }
                    else
                    { //If it’s not a tie and p1 didn’t win, then computer wins.
                        round.Outcome = 2;
                    }

                    game.rounds.Add(round);//add this round to the games List of rounds

                    //search the game.rounds List<> to see if one player has 2 wins
                    //if not loop to another round
                    int numP1Wins = game.rounds.Count(x => x.Outcome == 1);//get how many rounds p1 has won.
                    int numComputerWins = game.rounds.Count(x => x.Outcome == 2);//get how many rounds computer has won.

                    //assign the winner to the game and increment wins and losses for both
                    System.Console.WriteLine($"\tP1wins => {numP1Wins} \n\tComputer wins {numComputerWins}");
                    if (numP1Wins == 2)
                    {
                        game.winner = p1;
                        p1.record["wins"]++;//increments wins and losses.
                        computer.record["losses"]++;//increments wins and losses.
                        System.Console.WriteLine($"\t\t{game.winner.Name} wins!");//Announces winner
                    }
                    else if (numComputerWins == 2)
                    {
                        game.winner = computer;
                        p1.record["losses"]++;//increments wins and losses.
                        computer.record["wins"]++;//increments wins and losses.
                        System.Console.WriteLine($"\t\t{game.winner.Name} wins!");//Announces winner
                    }
                }//end of rounds loop

                games.Add(game);

            } while (choice != 2);//end of game loop

            PrintAllCurrentData(games, players, rounds);
        }//end of main
        public static void PrintAllCurrentData(List<Game> games, List<Player> players, List<Round> rounds)
        {
            foreach (var game in games)
            {
                System.Console.WriteLine($"Player1 Name => {game.Player1.Name}\nComputer Name => {game.Computer.Name}\n Winner is => {game.winner.Name}");
                System.Console.WriteLine($"\t--- Games Rounds --- ");
                foreach (Round round in game.rounds)
                {
                    System.Console.WriteLine($"Player1 => {round.player1.Name}, P1 choice => {round.p1Choice}");
                    System.Console.WriteLine($"Player2 => {round.Computer.Name}, Computer choice => {round.ComputerChoice}");
                    System.Console.WriteLine($"Round Outcome =>{round.Outcome}");
                }
            }
            System.Console.WriteLine("Player Roster.");
            foreach (var player in players)
            {
                System.Console.WriteLine($"Player {player.Name} is {player.record["wins"]} - {player.record["losses"]}2");
            }

        }

    }//end of program
}//end of namaespace
