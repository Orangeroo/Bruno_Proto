using UnityEngine;
using System.Collections;

public class Loin : BankObject {

	private bool isCollected = false;
	public Vector3 directionAfterCollect = Vector3.left * 2 + Vector3.up * 5;
	public Sprite openCoin;
	public Sprite closedCoin;
	public bool IsUsed = false; // to be used by the LoinSpawner

	void Awake()
    {

		this.bankPosition = transform.position;
	}


	// The coin was collected
	void OnTriggerEnter2D(Collider2D col)
    {
		if(col.tag == "Player")
		{
			// Add score
			Score.Instance.AddScore();
			isCollected = true;
		}
	}
	
	void Update()
	{
		// Once collected, move it out of the screen
		if( isCollected )
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = openCoin;
			this.transform.Translate(directionAfterCollect * Time.deltaTime, Camera.main.transform);
		}

	}

	public override void ReturnToBank()
	{
		this.isCollected = false;
		gameObject.GetComponent<SpriteRenderer>().sprite = closedCoin;

		base.ReturnToBank();
	}
}
