using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    private float speed = 50f;
    private float Force = 0f;
    // 定义了射箭时箭的一些物理属性
    public void shoot(GameObject arrow, Vector3 dir)
    {
        arrow.transform.up = dir;
        arrow.GetComponent<Rigidbody>().velocity = dir * speed;
        Force = Random.Range(-100, 100);
        addWind(arrow);
    }

    private void addWind(GameObject arrow) { arrow.GetComponent<Rigidbody>().AddForce(new Vector3(Force, 0, 0), ForceMode.Force); }

    public float getWindForce()
    {
        return Force > 0 ? Force : -1 * Force;
    }
    public string getWindDirection()
    {
        if (Force < 0)
        {
            return "Left";
        }
        else
        {
            return "Right";
        }
    }
}