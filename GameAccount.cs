using System;
using System.Collections.Generic;

namespace Лаб;

public class GameAccount
{
    public string userName { get; private set; }
    private int _curentRating;
    private int _gamesCount;
    private List<HistoryNote> history = new();

    private const int losestore = 5;
    private const int winstore = 10;

    public void WinGame()
    {
        _gamesCount++;
        _curentRating += winstore;
    }

    public void LoseGame()
    {
        _gamesCount++;
        if (_curentRating > 6)
            _curentRating -= losestore;
    }

    public void Stats()
    {
        Console.WriteLine("Game Stats of Player: " + userName + "\n\tPlayer Rating: " + _curentRating +
                          "\n\tGames Count: " + _gamesCount + "\n");
    }

    public void ShowHistory()
    {
        Console.WriteLine($"Personally Game History of {userName}:");
        foreach (var note in history)
            note.ShowNote();
    }

    public GameAccount(string userName)
    {
        this.userName = userName;
        _curentRating = 1000;
        _gamesCount = 0;
    }

    public void NewHistoryNote(HistoryNote note)
    {
        history.Add(new HistoryNote(ref note));
    }
}