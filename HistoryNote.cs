using System;

namespace Лаб;

public class HistoryNote
        {
            private static int _currnetGameId = 0;
            private int _gameId;
            private GameAccount _playerOneName;
            private string? _playerOneChoose;
            private GameAccount _playerTwoName;
            private string? _playerTwoChoose;
            private int _gameResult; //1r2 win 0-draw

            public HistoryNote(GameAccount playerOneName, GameAccount playerTwoName, int gameResult,
                string playerOneChoose, string playerTwoChoose)
            {
                _playerOneName = playerOneName;
                _playerTwoName = playerTwoName;
                _gameResult = gameResult;
                _gameId = _currnetGameId++;
                _playerOneChoose = playerOneChoose;
                _playerTwoChoose = playerTwoChoose;
            }

            public HistoryNote(ref HistoryNote CopyNote)
            {
                this._playerOneName = CopyNote._playerOneName;
                this._playerTwoName = CopyNote._playerTwoName;
                this._gameResult = CopyNote._gameResult;
                this._gameId = CopyNote._gameId;
                this._playerOneChoose = CopyNote._playerOneChoose;
                this._playerTwoChoose = CopyNote._playerTwoChoose;
            }

            public void ShowNote()
            {
                Console.WriteLine("\tGame ID: " + _gameId + "\n\tPlayer One: " + _playerOneName.userName +
                                  "\t\tChoose: " + _playerOneChoose + "\n\tPlayer Two: " +
                                  _playerTwoName.userName +
                                  "\t\tChoose: " + _playerTwoChoose);
                Console.WriteLine(_gameResult == 0
                    ? "\tResult of game: DRAW"
                    : ("\tWinner of the game is " +
                       (_gameResult == 1 ? _playerOneName.userName : _playerTwoName.userName)));
                Console.WriteLine("--------------------------------------");
            }
        }