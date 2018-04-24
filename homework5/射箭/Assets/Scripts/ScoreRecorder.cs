using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour
{
    private int Score = 0;
    public void countScore(string theTag)
    {
        if (theTag == "Cylinder1") Score += 5;
        else if (theTag == "Cylinder2") Score += 4;
        else if (theTag == "Cylinder3") Score += 3;
        else if (theTag == "Cylinder4") Score += 2;
        else if (theTag == "Cylinder5") Score += 1;
    }
    public int getScore() { return Score; }
}