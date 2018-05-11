using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//并发顺序
public class SSActionManager : MonoBehaviour {

    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();
    private List<SSAction> waitingAdd = new List<SSAction>();
    private List<int> waitingDelete = new List<int>();

    protected void Start () {
	
	}

    protected void Update() {
	    foreach (SSAction ac in waitingAdd) {
            actions[ac.GetInstanceID()] = ac;
        }
        waitingAdd.Clear();

        foreach (KeyValuePair<int, SSAction> kv in actions) {
            SSAction ac = kv.Value;
            if (ac.destroy)
                waitingDelete.Add(kv.Key);
            else if (ac.enable)
                ac.Update();
        }

        foreach (int key in waitingDelete) {
            SSAction ac = actions[key];
            actions.Remove(key);
            DestroyObject(ac);
        }
        waitingDelete.Clear();
    }

    public void runAction(GameObject gameObj, SSAction action, ISSActionCallback manager) {
        //先把该对象现有的动作销毁（与原来不同部分）
        for (int i = 0; i < waitingAdd.Count; i++) {
            if (waitingAdd[i].gameObject.Equals(gameObj)) {
                SSAction ac = waitingAdd[i];
                waitingAdd.RemoveAt(i);
                i--;
                DestroyObject(ac);
            }
        }
        foreach (KeyValuePair<int, SSAction> kv in actions) {
            SSAction ac = kv.Value;
            if (ac.gameObject.Equals(gameObj)) {
                ac.destroy = true;
            }
        }

        action.gameObject = gameObj;
        action.transform = gameObj.transform;
        action.callBack = manager;
        waitingAdd.Add(action);
        action.Start();
    }
}

public class SSAction : ScriptableObject
{
    public bool enable = true;
    public bool destroy = false;

    public GameObject gameObject { get; set; }
    public Transform transform { get; set; }
    public ISSActionCallback callBack { get; set; }

    protected SSAction() { }

    public virtual void Start()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Update()
    {
        throw new System.NotImplementedException();
    }
}

public class CCMoveToAction : SSAction
{
    public Vector3 target;
    public float speed;
    public bool isCatching;    //判定此动作是否为追捕（与原来不同）

    public static CCMoveToAction CreateSSAction(Vector3 _target, float _speed, bool _isCatching)
    {
        CCMoveToAction action = ScriptableObject.CreateInstance<CCMoveToAction>();
        action.target = _target;
        action.speed = _speed;
        action.isCatching = _isCatching;
        return action;
    }

    public override void Start()
    {

    }

    public override void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed);
        if (this.transform.position == target)
        {
            this.destroy = true;
            if (!isCatching)    //根据不同的动作类型回调函数传递不同的参数
                this.callBack.SSActionEvent(this);
            else
                this.callBack.SSActionEvent(this, SSActionEventType.Completed, SSActionTargetType.Catching);
        }
    }
}