using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUIbloodbar : MonoBehaviour
{

    public float initblood = 0.0f;
    private float currentblood;
    private Rect BloodBar;
    private Rect Add;
    private Rect Minus;

    void Start()
    {
        BloodBar = new Rect(360, 140, 50, 2);
        Add = new Rect(330, 110, 50, 20);
        Minus = new Rect(390, 110, 50, 20);
        currentblood = initblood;
    }

    void OnGUI()
    {
        if (GUI.Button(Add, "Add"))
        {
            if(currentblood + 0.1f > 1.0f)
            {
                currentblood = 1.0f;
            }
            else
            {
                currentblood += 0.1f;
            }
        }
        if (GUI.Button(Minus, "Minus"))
        {
            if (currentblood - 0.1f < 0.0f)
            {
                currentblood = 0.0f;
            }
            else
            {
                currentblood -= 0.1f;
            }
        }

        initblood = Mathf.Lerp(initblood, currentblood, 0.05f);
        GUI.HorizontalScrollbar(BloodBar, 0.0f, initblood, 0.0f, 1.0f);
    }
}