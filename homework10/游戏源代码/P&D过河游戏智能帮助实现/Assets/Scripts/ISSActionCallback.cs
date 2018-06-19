using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mygame;

// 动作事件接口
public interface ISSActionCallback
{
    void OnActionCompleted(SSAction action);
}