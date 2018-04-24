using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private ActionManager actionManager;
    private ScoreRecorder scoreRecorder;
    private ArrowFactory arrowFactory;

    void Awake()
    {
        Director director = Director.getinstance();
        director.Controller = this;
        actionManager = (ActionManager)FindObjectOfType(typeof(ActionManager));
        scoreRecorder = (ScoreRecorder)FindObjectOfType(typeof(ScoreRecorder));
        arrowFactory = (ArrowFactory)FindObjectOfType(typeof(ArrowFactory));
    }

    public ArrowFactory getFactory() { return arrowFactory; }
    public ScoreRecorder getRecorder() { return scoreRecorder; }
    public ActionManager getActionManager() { return actionManager; }
    public void shootArrow(Vector3 dir)
    {
        GameObject arrow = arrowFactory.getArrow();
        arrow.transform.position = new Vector3(0, 0, -1);
        actionManager.shoot(arrow, dir);
    }
}

public class Director : System.Object
{
    private static Director _instance;

    public SceneController Controller { get; set; }

    public static Director getinstance()
    {
        if (_instance == null) _instance = new Director();
        return _instance;
    }
}