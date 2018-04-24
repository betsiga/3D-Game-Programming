using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFactory : MonoBehaviour
{
    private List<GameObject> Shooted;
    private List<GameObject> Unshooted;
    public GameObject arrow;

    void Awake()
    {
        Unshooted = new List<GameObject>();
        Shooted = new List<GameObject>();
        arrow = Instantiate(Resources.Load("Prefabs/Arrow")) as GameObject;
        arrow.SetActive(false);
    }
    void Update()
    {
        for (int i = 0; i < Shooted.Count; i++)
        {
            GameObject arrow_temp = Shooted[i];
            if (arrow_temp.transform.position.y < -100)
            {
                Shooted.RemoveAt(i);
                Unshooted.Add(arrow_temp);
            }
        }
    }
    public GameObject getArrow()
    {
        GameObject arrow_temp;
        if (Unshooted.Count == 0)
        {
            arrow_temp = GameObject.Instantiate(arrow) as GameObject;
            arrow_temp.SetActive(true);
        }
        else
        {
            arrow_temp = Unshooted[0];
            arrow_temp.SetActive(true);
            if (arrow_temp.GetComponent<Rigidbody>() == null)
                arrow_temp.AddComponent<Rigidbody>();
            Component[] comp = arrow_temp.GetComponentsInChildren<CapsuleCollider>();
            foreach (CapsuleCollider i in comp)
                i.enabled = true;
            arrow_temp.GetComponent<CapsuleCollider>().isTrigger = true;
            Unshooted.RemoveAt(0);
        }
        Shooted.Add(arrow_temp);
        return arrow_temp;
    }
}