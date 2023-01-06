using System;
using System.Collections.Generic;

namespace Лаб;

public class Game
        {
            private List<GameAccount> _accounts = new();
            private List<HistoryNote> _global_history = new();

            private enum GameAtributes
            {
                Rock = 1,
                Paper = 2,
                Scissors = 3
            }

            public void GameSimulation(int playerOneId, int playerTwoId)
            {
                Random rand = new Random();
                string? playerOneChoose = Enum.GetName(typeof(GameAtributes), rand.Next(1, 3));
                string? playerTwoChoose = Enum.GetName(typeof(GameAtributes), rand.Next(1, 3));

                int gameResult = -1; //1 - player 1 win, 2 - player 2 win, 0 - drow

                ///////////////////////////////////////////////////
                switch (playerOneChoose)
                {
                    case "Rock":
                        switch (playerTwoChoose)
                        {
                            case "Rock":
                                gameResult = 0;
                                break;
                            case "Paper":
                                gameResult = 2;
                                break;
                            case "Scissors":
                                gameResult = 1;
                                break;
                        }

                        break;
                    case "Paper":
                        switch (playerTwoChoose)
                        {
                            case "Rock":
                                gameResult = 1;
                                break;
                            case "Paper":
                                gameResult = 0;
                                break;
                            case "Scissors":
                                gameResult = 2;
                                break;
                        }

                        break;
                    case "Scissors":
                        switch (playerTwoChoose)
                        {
                            case "Rock":
                                gameResult = 2;
                                break;
                            case "Paper":
                                gameResult = 1;
                                break;
                            case "Scissors":
                                gameResult = 0;
                                break;
                        }

                        break;
                }

                switch (gameResult)
                {
                    case 1:
                        _accounts[playerOneId].WinGame();
                        _accounts[playerTwoId].LoseGame();
                        break;

                    case 2:
                        _accounts[playerTwoId].WinGame();
                        _accounts[playerOneId].LoseGame();
                        break;

                    default:
                        _accounts[playerOneId].LoseGame();
                        _accounts[playerTwoId].LoseGame();
                        break;
                }

                ///////////////////////////////////////////////////
                HistoryNote(playerOneId, playerTwoId, playerOneChoose, playerTwoChoose, gameResult);
            }

            private void HistoryNote(int playerOneId, int playerTwoId, string? playerOneChoose, string? playerTwoChoose,
                int winner)
            {
                _global_history.Add(new HistoryNote(_accounts[playerOneId], _accounts[playerTwoId], winner,
                    playerOneChoose, playerTwoChoose));
                _accounts[playerOneId].NewHistoryNote(_global_history[_global_history.Count - 1]);
                _accounts[playerTwoId].NewHistoryNote(_global_history[_global_history.Count - 1]);
            }

            public void NewPlayer()
            {
                Console.Write("Enter Name for new Player:\n::");
                string? nick = Console.ReadLine();
                try
                {
                    if (nick.Equals(null))
                        throw new Exception("Eroor...Trying create new account without Name");
                    _accounts.Add(new GameAccount(nick));
                    Console.WriteLine(
                        $"New Player created successfully. Player`s {nick} ID: " + (_accounts.Count - 1));
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            public int NumberOfPlayers()
            {
                return _accounts.Count;
            }

            public int CheackAvaliablePlayer(int PlayerOneID, int PlayerTwoID)
            {
                try
                {
                    if (PlayerOneID > _accounts.Count || PlayerOneID < 0)
                        throw new Exception("Error...Player One ID is not detected");

                    if (PlayerTwoID > _accounts.Count || PlayerTwoID < 0)
                        throw new Exception("Error...Player Two ID is not detected");

                    if (PlayerTwoID == PlayerOneID)
                        throw new Exception("Error...Can not be the same players is on game");
                    return 1;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return 0;
                }
            }

            public void ShowHistory()
            {
                Console.WriteLine("Global Game History:");
                foreach (var note in _global_history)
                    note.ShowNote();
            }

            public void ShowStatsOfPlayer(int PlayerID)
            {
                _accounts[PlayerID].Stats();
            }

            public void ShowPersonallyHistoryOfPlayer(int PlayerID)
            {
                _accounts[PlayerID].ShowHistory();
            }
        }