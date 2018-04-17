using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    public GameObject plane;
    GameStatus _gameStatus;
    ViewStatus _ViewStatus;
    IUserInterface _uerInterface;
    IQueryStatus _queryStatus;
    IScore _changeScore;

    void Start()
    {
        GameObject plane = GameObject.Instantiate<GameObject>(Resources.Load("Prefabs/plane") as GameObject);
        plane.transform.position = new Vector3(0f, 0f, 70f);
        _gameStatus = GameStatus.ini;
        _ViewStatus = ViewStatus.waiting;
        _uerInterface = ViewController.getController() as IUserInterface;
        _queryStatus = ViewController.getController() as IQueryStatus;
        _changeScore = ViewController.getController() as IScore;
    }

    void Update()
    {
        _gameStatus = _queryStatus.queryGameStatus();
        _ViewStatus = _queryStatus.queryViewStatus();

        if (_gameStatus == GameStatus.ini)
        {
            if (_ViewStatus == ViewStatus.waiting)
            {
                _uerInterface.sendDisk();
            }
            if (_ViewStatus == ViewStatus.shooting && Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Disk")
                {
                    _uerInterface.destroyDisk(hit.collider.gameObject);
                    _changeScore.addScore();
                }
            }
        }
    }
}