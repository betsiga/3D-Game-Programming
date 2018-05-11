# 巡逻兵游戏 #

### 游戏演示视频 ###

[演示视频](http://v.youku.com/v_show/id_XMzYwMDAwOTYyNA==.html?spm=a2h3j.8428770.3416059.1 "")

### 游戏效果展示 ###

![](https://i.loli.net/2018/05/11/5af5a851d233d.png)

### 游戏设计要求 ###

- 创建一个地图和若干巡逻兵(使用动画)；
- 每个巡逻兵走一个3~5个边的凸多边型，位置数据是相对地址。即每次确定下一个目标位置，用自己当前位置为原点计算；
- 巡逻兵碰撞到障碍物，则会自动选下一个点为目标；
- 巡逻兵在设定范围内感知到玩家，会自动追击玩家；
- 失去玩家目标后，继续巡逻；
- 计分：玩家每次甩掉一个巡逻兵计一分，与巡逻兵碰撞游戏结束；

### 游戏规则 ###

- 通过键盘上下左右控制玩家的方向
- 安全离开一个巡逻兵的范围后，score+1
- 被巡逻兵抓到，游戏结束
- 玩家进入巡逻兵范围后，巡逻兵的速度增大
- 为了增大难度，巡逻兵的速度随着时间逐渐增大

### 部分主要功能###

1.巡逻兵碰撞到障碍物，则会自动选下一个点为目标；

首先在挂载在巡逻兵上的PatrolBehaviour.cs里面判断巡逻兵与障碍物碰撞

```
	void OnCollisionStay(Collision e) {
		if (e.gameObject.name.Contains("Patrol") || e.gameObject.name.Contains("fence") || e.gameObject.tag.Contains("FenceAround")) {
			isCatching = false;
			addAction.addRandomMovement(this.gameObject, false);
		}
		...
	}
```

然后具体实现放到GameModel.cs中，添加随机移动方向
	
```
	public void addRandomMovement(GameObject sourceObj, bool isActive) {
		int index = getIndexOfObj(sourceObj);
		int randomDir = getRandomDirection(index, isActive);
		PatrolLastDir[index] = randomDir;
		sourceObj.transform.rotation = Quaternion.Euler(new Vector3(0, randomDir * 90, 0));
		Vector3 target = sourceObj.transform.position;
		switch (randomDir) {
			case Diretion.UP;
				target += new Vector3(0, 0, 1);
				break;
			case Diretion.DOWN:
				target += new Vector3(0, 0, -1);
				break;
			case Diretion.LEFT:
				target += new Vector3(-1, 0, 0);
				break;
			case Diretion.RIGHT:
				target += new Vector3(1, 0, 0);
				break;
		}
		addSingleMoving(sourceObj, target, PERSON_SPEED_NORMAL, false);
	}
```
	

2.订阅与发布模式

通过GameEventManager.cs发布玩家得分与游戏进行情况的信息，TextBehaviour.cs来获得信息。这样做分离了代码功能，信息的发布者只考虑发布信息，而不考虑订阅者如何利用信息。

```
	//GameEventManager.cs
	public delegate void GameOverAction();
	public static event GameOverAction myGameOverAction;
	public void patrolHitPlayerAndGameover() {
		if (myGameOverAction != null)
		myGameOverAction();
	}
    
	//TextBehaviour.cs
	void OnEnable() {
	GameEventManager.myGameScoreAction += gameScore;
	GameEventManager.myGameOverAction += gameOver;
	}
    
	void gameScore() {
		if (textType == 0) {
			score++;
			this.gameObject.GetComponent<Text>().text = "Score: " + score;
		}
	} 

	void gameOver() {
		if (textType == 1)
			this.gameObject.GetComponent<Text>().text = "Game Over";
	}

```

3.巡逻兵的速度随着时间逐渐增大

```
	//GameModel.cs
	private float normal_speed = 0.05f;
	private float catching_speed = 0.06f;
	
	protected new void Update() {
		normal_speed += 0.00002f;
		catching_speed += 0.00002f;
		base.Update();
	}
```
