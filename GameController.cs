using System;

namespace Лаб;

public class GameController
{
    private Game currentGame;
    int playerOneId, playerTwoId;

    public GameController()
    {
        currentGame = new Game();
        Console.WriteLine("Game Created...Avalible accounts: 0. Creating new player...");
        while (CreatePlayers());
        Console.WriteLine("--------------------------------------");
        Simuliation();
    }


    private void Simuliation()
    {
        Console.Write("Choose the number of simulations of the game \"rock paper scissors\"\n::");
        int countOfGames = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < countOfGames; i++)
        {
            do
            {
                Console.Write($"Choose first players for game #{i} (input ID) \n::");
                playerOneId = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Choose second players for game #{i} (input ID) \n::");
                playerTwoId = Convert.ToInt32(Console.ReadLine());
            } while (currentGame.CheackAvaliablePlayer(playerOneId, playerTwoId) != 1);

            currentGame.GameSimulation(playerOneId, playerTwoId);
        }

        Console.Write("Games already ended. Choose player to display Stats (player ID)\n::");
        currentGame.ShowStatsOfPlayer(Convert.ToInt32(Console.ReadLine()));
        currentGame.ShowHistory();
        Console.Write("Choose player to display personally history\n::");
        currentGame.ShowPersonallyHistoryOfPlayer(Convert.ToInt32(Console.ReadLine()));
    }

    private bool CreatePlayers()
    {
        currentGame.NewPlayer();
        if (currentGame.NumberOfPlayers() < 2) return true;
        Console.Write(
            $"\nNumber of Avaliable players is {currentGame.NumberOfPlayers()}.Do you wanna create one more?(y/n)\n::");
        if (Console.ReadLine() != "y")
            return false;
        return true;
    }
}