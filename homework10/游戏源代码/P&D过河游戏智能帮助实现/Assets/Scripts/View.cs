using UnityEngine;
using System.Collections;
using mygame;

public class View : MonoBehaviour
{
    Controller scene;
    QueryGameStatus state;
    UserActions action;
    

    void Start()
    {
        scene = Controller.GetInstance();
        state = Controller.GetInstance() as QueryGameStatus;
        action = Controller.GetInstance() as UserActions;
    }

    void OnGUI()
    {

        if (state.getMessage() != "")
        {
            if (GUI.Button(new Rect(300, 200, 300, 100), state.getMessage())) action.restart();
        }
        else
        {
            
            if (!state.isMoving() && scene.ifstart)
            {
                if (GUI.Button(new Rect(425, 80, 50, 25), "GO")) action.moveBoat();
                if (GUI.Button(new Rect(425, 110, 50, 25), "NEXT")) StartCoroutine(action.doNext()); ;
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
                if (GUI.Button(new Rect(375, 200, 50, 20), "OFF")) action.offBoatL();
                if (GUI.Button(new Rect(475, 200, 50, 20), "OFF")) action.offBoatR();
            }
        }
    }
}