using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{
    void Start()
    {
        ViewController.getController()._View = this.gameObject.AddComponent<View>();
    }

    void Update()
    {

    }
}

public class ViewController : IUserInterface, IQueryStatus, setStatus, IScore
{
    public int sendDiskCount { get; private set; }
    private static ViewController _ViewController;
    private GameStatus _gameStatus;
    private ViewStatus _ViewStatus;
    public View _View;
    private DiskFactory _diskFactory = DiskFactory.getFactory();

    public static ViewController getController()
    {
        if (_ViewController == null)
            _ViewController = new ViewController();
        return _ViewController;
    }

    public void sendDisk()
    {
        int diskCount = _View.diskCount;
        var diskList = _diskFactory.prepareDisks(diskCount);
        _View.sendDisk(diskList);
    }

    public void destroyDisk(GameObject disk)
    {
        _View.destroyDisk(disk);
        _diskFactory.recycleDisk(disk);
    }

    public GameStatus queryGameStatus() { return this._gameStatus; }
    public ViewStatus queryViewStatus() { return this._ViewStatus; }

    public void setGameStatus(GameStatus _gameStatus) { this._gameStatus = _gameStatus; }
    public void setViewStatus(ViewStatus _ViewStatus) { this._ViewStatus = _ViewStatus; }

    public void addScore() { GameModel.getGameModel().addScore(); }
    public void subScore() { GameModel.getGameModel().subScore(); }
    public int getScore() { return GameModel.getGameModel().score; }
    public int getRound() { return GameModel.getGameModel().round; }
    public void update() { _View.ViewUpdate(); }
}


public interface IUserInterface
{
    void sendDisk();
    void destroyDisk(GameObject disk);
}

public enum GameStatus
{
    ini = 0,
    win = 1,
    fail = 2
}

public enum ViewStatus
{
    waiting = 0,
    shooting = 1
}

public interface IQueryStatus
{
    GameStatus queryGameStatus();
    ViewStatus queryViewStatus();
}

public interface setStatus
{
    void setGameStatus(GameStatus _gameStatus);
    void setViewStatus(ViewStatus _ViewStatus);
}

public interface IScore
{
    void addScore();
    void subScore();
    int getScore();
    int getRound();
}

