using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInteraction : MonoBehaviour
{
    GameObject scoreText;
    GameObject gameStatuText;
    GameObject roundText;
    IScore _getScore = ViewController.getController() as IScore;
    IQueryStatus _getGameStatu = ViewController.getController() as IQueryStatus;

    void Start()
    {
        scoreText = GameObject.Find("Score");
        gameStatuText = GameObject.Find("GameStatu");
        roundText = GameObject.Find("Round");
    }

    void Update()
    {
        string score = Convert.ToString(_getScore.getScore());
        string round = Convert.ToString(_getScore.getRound());
        if (_getGameStatu.queryGameStatus() == GameStatus.fail)
            gameStatuText.GetComponent<Text>().text = "You fail!";
        else if (_getGameStatu.queryGameStatus() == GameStatus.win)
            gameStatuText.GetComponent<Text>().text = "You win!";
        scoreText.GetComponent<Text>().text = "Score:" + score;
        roundText.GetComponent<Text>().text = "Round:" + round;
    }
}

