using UnityEngine;
using System.Collections;

public class LevelBlock : MonoBehaviour {
	public Transform start;
	public Transform end;
	public Transform trigger;
	public float length; // length of the entire block
	public bool isUsed { get; private set; }

	void Awake()
	{
		length = end.position.x - start.position.x;
		isUsed = false;
	}

	// Instantiate/move obstacles etc to prepare the block here
	public virtual void Init(){}

	public void MoveBlock(Vector2 position, bool isStartPosition) 
	{
		this.SetIsUsed(true);

		Vector2 movePosition = new Vector2(position.x, 0);

		if(isStartPosition)
		{
			movePosition = new Vector2(position.x + length/2, 0);
		}

		this.transform.position = movePosition;

		this.Init();
	}

	public void SetIsUsed(bool isUsed)
	{
		this.isUsed = isUsed;

		// if no longer used, move it back to the list of unused blocks on the block spawner
		if(!isUsed)
		{
			this.transform.parent.GetComponent<LevelBlockSpawner>().AddUnusedBlock(this);
			this.trigger.GetComponent<LevelBlockTrigger>().ResetTrigger();
		}
	}



}
