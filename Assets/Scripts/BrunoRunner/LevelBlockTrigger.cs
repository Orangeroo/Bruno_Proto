using UnityEngine;
using System.Collections;

public class LevelBlockTrigger : MonoBehaviour {

	private bool isTriggered = false;

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player" && !isTriggered)
		{
			isTriggered = true;
			Vector2 spawnLocation = this.transform.parent.GetComponent<LevelBlock>().end.position;
			LevelBlockSpawner.Instance.SpawnNewBlock(spawnLocation);
		}
	}

	public void ResetTrigger()
	{
		isTriggered = false;
	}
}
