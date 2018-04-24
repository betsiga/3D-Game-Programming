using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class UserInterface:MonoBehaviour
    {
        GameObject WindDirectionText;
        GameObject WindForceText;
        GameObject ScoreText;
        SceneController controller;
        void Start()
        {
            WindDirectionText = GameObject.Find("Wind Direction");
            WindForceText = GameObject.Find("Wind Force");
            ScoreText = GameObject.Find("Score");
            controller = Director.getinstance().Controller;
            ScoreText.GetComponent<Text>().text = "Score: " + controller.getRecorder().getScore(); 
        }
   
        void Update()
        {
            WindDirectionText.GetComponent<Text>().text = "Direction: " + controller.getActionManager().getWindDirection();
            WindForceText.GetComponent<Text>().text = "Force: " + controller.getActionManager().getWindForce(); 
            if (Input.GetMouseButtonDown(0))
            {
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                controller.shootArrow(mouseRay.direction);   
            }
            ScoreText.GetComponent<Text>().text = "Score: " + controller.getRecorder().getScore();
        }
    }
}
