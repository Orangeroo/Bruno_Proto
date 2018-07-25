using UnityEngine;
using System.Collections;

public class BankObject : MonoBehaviour {

	public Vector3 bankPosition{get;set;}
	public bool isInUse;

	void Awake()
	{
		bankPosition = transform.position;
		isInUse = false;
	}

	public virtual void ReturnToBank()
	{
		transform.position = bankPosition;
		isInUse = false;
	}

	public Vector2 GetLocation()
	{
		return transform.position;
	}

	public void MoveTo(Vector2 newposition)
	{
		transform.position = newposition;
		isInUse = true;
	}

	public void CheckAndSetIsInUse()
	{
		this.isInUse = (transform.position == this.bankPosition);
	}
}
