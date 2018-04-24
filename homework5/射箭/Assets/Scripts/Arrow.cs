using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private string theTag;
    private ScoreRecorder recorder;
    void Awake()
    {
        theTag = "";
        recorder = (ScoreRecorder)FindObjectOfType(typeof(ScoreRecorder));
    }
    // 箭射中靶触发了碰撞事件
    void OnTriggerEnter(Collider target)
    {
        theTag = target.gameObject.tag;
        Destroy(GetComponent<Rigidbody>());
        Component[] comp = GetComponentsInChildren<CapsuleCollider>();
        foreach (CapsuleCollider i in comp)
            i.enabled = false;
        GetComponent<CapsuleCollider>().isTrigger = false;
        recorder.countScore(theTag);

    }
    
}