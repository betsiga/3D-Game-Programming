using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mygame;

public class View : MonoBehaviour
{

    SSDirector one;
    UserAction action;

    // Use this for initialization  
    void Start()
    {
        one = SSDirector.GetInstance();
        action = SSDirector.GetInstance() as UserAction;
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 25;
        if (one.state == State.Win)
        {
            if (GUI.Button(new Rect(300, 200, 300, 100), "WIN\n(click here to reset)"))
            {
                action.reset();
            }
        }
        if (one.state == State.Lose)
        {
            if (GUI.Button(new Rect(300, 200, 300, 100), "LOSE\n(click here to reset)"))
            {
                action.reset();
            }
        }

        if (GUI.Button(new Rect(425, 80, 50, 25), "GO"))
        {
            action.moveShip();
        }
        if (GUI.Button(new Rect(375, 200, 40, 20), "OFF"))
        {
            action.offShipL();
        }
        if (GUI.Button(new Rect(475, 200, 40, 20), "OFF"))
        {
            action.offShipR();
        }
        if (GUI.Button(new Rect(200, 175, 40, 20), "ON"))
        {
            action.priestSOnB();
        }
        if (GUI.Button(new Rect(275, 175, 40, 20), "ON"))
        {
            action.devilSOnB();
        }
        if (GUI.Button(new Rect(575, 175, 40, 20), "ON"))
        {
            action.priestEOnB();
        }
        if (GUI.Button(new Rect(650, 175, 40, 20), "ON"))
        {
            action.devilEOnB();
        }
    }
}