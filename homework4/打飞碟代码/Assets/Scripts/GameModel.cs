using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameModel : IScore
{
    public int score { get; private set; }
    public int round { get; private set; }
    private int trial = 0;
    private static GameModel _gameModel;

    public static GameModel getGameModel()
    {
        if (_gameModel == null)
        {
            _gameModel = new GameModel();
            _gameModel.round = 1;
        }
        return _gameModel;
    }

    public void addScore()
    {
        score += 10;
        trial++;
        if (checkUpdate())
        {
            this.round++;
            trial = 0;
            ViewController.getController().update();
        }
    }

    public void subScore()
    {
        score -= 5;
        trial++;
        if (score < 0)
        {
            ViewController.getController().setGameStatus(GameStatus.fail);
        }
    }

    public bool checkUpdate()
    {
        if (trial >= 9)
            return true;
        return false;
    }

    public int getScore() { return GameModel.getGameModel().score; }
    public int getRound() { return GameModel.getGameModel().round; }
}