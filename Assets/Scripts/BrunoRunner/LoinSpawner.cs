using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LoinSpawner : MonoBehaviour {
	// Singleton
	public static LoinSpawner Instance;
	public List<BankObject> bank;

	void Awake()
	{
		// Register the singleton
		if( Instance != null )
		{
			Debug.LogError("Multiple instances of Loin Spawner");
		}
		
		Instance = this;

		// Get loins
		bank = new List<BankObject>();

		for(int i=0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			
			if(child != null)
			{
				BankObject tempObj = child.GetComponent<BankObject>();
				bank.Add(tempObj);
			}
		}
	}

	// ----------------------------------------------------------------------------------------------------------------------
	// Get an unused loin, if not return a random first one
	// ----------------------------------------------------------------------------------------------------------------------

	BankObject GetUnusedLoin()
	{
		BankObject rand = bank[1];// bank[1];
		for(int i=0; i< bank.Count; i++)
		{
			if(!bank[i].isInUse)
			{
				return bank[i];
			}
		}

		if(rand.isInUse)
		{
			rand = null;
		}
		return rand; // this shouldn't happen
	}
	// ----------------------------------------------------------------------------------------------------------------------
	// "Create" the loin
	// ----------------------------------------------------------------------------------------------------------------------

	void CreateLoin(Vector2 position)
	{
		BankObject loin = this.GetUnusedLoin();

		if(loin != null)
		{
			loin.MoveTo(position);
		}
				
	}
	// ----------------------------------------------------------------------------------------------------------------------
	// Create a row of loins
	// ----------------------------------------------------------------------------------------------------------------------

	public Vector2 CreateRow(Vector2 startposition, int gapBetweenDiamons, int nrDiamonds)
	{
		Vector2 position = new Vector2(startposition.x, startposition.y);
		
		for(int i = 1; i <= nrDiamonds; i++)
		{
			CreateLoin(position);
			position.x = position.x + gapBetweenDiamons;
		}
		
		return position;
	}

	public void CreateRow(Vector2 startposition)
	{
		this.CreateRow(startposition, 1, 7);
	}

	// ----------------------------------------------------------------------------------------------------------------------
	// Create an arc
	// ----------------------------------------------------------------------------------------------------------------------

	public void CreateArc(int radius, float degrees, int nrLoins, Vector2 startposition)
	{
		// Calculate the nr of degrees change per diamond
		float degreesPerLoin = degrees/nrLoins;
		float angle = degrees - 90;
		float angleInRads = 0;
		Vector2 position = new Vector2();
		Vector2 firstLoinPosition = startposition + new Vector2(radius, 0);

		for(int i = 0; i < nrLoins; i++)
		{
			angleInRads = angle * Mathf.Deg2Rad;
			position.x = firstLoinPosition.x + radius * Mathf.Sin(angleInRads);
			position.y = firstLoinPosition.y + radius * Mathf.Cos(angleInRads);
			this.CreateLoin(position);
			angle = angle - degreesPerLoin;
		}
	}
	
	public void CreateArc(Vector2 startposition, bool isHalf)
	{
		float degrees = 180f;
		int nrLoins = 10;
		
		if(isHalf)
		{
			degrees = 90f;
			nrLoins = 5;
		}
		
		this.CreateArc(3, degrees, nrLoins, startposition);
	}
}
