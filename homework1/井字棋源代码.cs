using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private int result = 2; //结果如何 平为0 1为O胜 -1为X胜
    private int turn = 1; // 轮到谁 1为O -1为X
    private int[,] checkerboard = new int[3, 3]; //3*3棋盘 0为空 1为O -1为X
                                                 // Use this for initialization
    void Reset()
    {
        turn = 1;
        result = 2;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
                checkerboard[i, j] = 0;
        }
    }
     void Win()
    {
        for (int i = 0; i < 3; i++)
        {
            if(checkerboard[1, i] == checkerboard[2, i] && checkerboard[0, i] == checkerboard[2, i])
            {
                if(checkerboard[0,i] != 0)
                {
                    result = checkerboard[0, i];
                    return;
                }
            }
            if (checkerboard[i, 1] == checkerboard[i, 2] && checkerboard[i, 0] == checkerboard[i, 2])
            {
                if (checkerboard[i, 0] != 0)
                {
                    result = checkerboard[i, 0];
                    return;
                }
            }
        }
        if (checkerboard[0, 0] == checkerboard[1, 1] && checkerboard[1, 1] == checkerboard[2, 2])
        {
            if (checkerboard[0, 0] != 0)
            {
                result = checkerboard[0, 0];
                return;
            }
        }
        if (checkerboard[0, 2] == checkerboard[1, 1] && checkerboard[1, 1] == checkerboard[2, 0])
        {
            if (checkerboard[0, 2] != 0)
            {
                result = checkerboard[0, 2];
                return;
            }
        }
        int flag = 0;
        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if (checkerboard[i, j] == 0)
                    flag = 1;
            }
        }
        if(flag == 0)
        {
            result = 0;
        }
    }
    void Start () {
        Reset();
	}

    
    void OnGUI()
    {
        if (GUI.Button(new Rect(325, 250, 100, 50), "RESET"))
            Reset();
        Win();
        if(result == 1)
        {
            GUI.Label(new Rect(352, 80, 100, 50), "O方获胜");
        }
        else if(result == -1)
        {
            GUI.Label(new Rect(352, 80, 100, 50), "X方获胜");
        }
        else if(result == 0)
        {
            GUI.Label(new Rect(360, 80, 100, 50), "平局");
        }
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if(checkerboard[i,j] == 1)
                    GUI.Button(new Rect(300 + i * 50, 100 + j * 50, 50, 50), "O");
                if (checkerboard[i,j] == -1)
                    GUI.Button(new Rect(300 + i * 50, 100 + j * 50, 50, 50), "X");
                if(GUI.Button(new Rect(300 + i * 50, 100 + j * 50, 50, 50), ""))
                {
                    if(result == 2)
                    {
                        checkerboard[i, j] = turn;
                        turn = -turn;
                    }
                }
                
            }
        }
    }
}
