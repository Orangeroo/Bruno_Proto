using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		// Do nothing for background/ground
		if(other.tag == "Background" || other.tag == "LevelBlock")
		{
			// do nothing
		}

		// If it is a game object, return it to the bank
		else if(other.tag == "BankObject")
		{
			BankObject obj = other.transform.gameObject.GetComponent<BankObject>();
			if(obj != null)
			{
				obj.ReturnToBank();
			}

		}

		else if(other.tag == "LevelBlockEnd")
		{
			other.transform.parent.GetComponent<LevelBlock>().SetIsUsed(false);
		}

		// Destroy everything else
		else
		{
			Destroy (other.gameObject);
		}

	}
}
