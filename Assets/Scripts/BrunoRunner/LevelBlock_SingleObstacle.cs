using UnityEngine;
using System.Collections;

public class LevelBlock_SingleObstacle : LevelBlock {

	// Locations for spawning stuff
	// - Loins
	public Transform loinLocation_beforeObstacleRow;
	public Transform loinLocation_beforeObstacleArc;
	public Transform loinLocation_jump;
	public Transform loinLocation_doubleJump;

	// - Obstacles
	public Transform obstacleLocation;
	public Transform obstacleLocationDoubleJump;

	// Game objects/obstacles
	public GameObject singleBlock;
	public GameObject doubleJumpBlock;

	public override void Init()
	{
		// Choose an obstacle
		bool isDoubleJumpBlock = SpawnObstacle();

		// Choose where to spawn loins
		SpawnLoinAfterObstacle(isDoubleJumpBlock);
		SpawnLoinBeforeObstacle(isDoubleJumpBlock);

	}

	bool SpawnObstacle()
	{
		int i = Random.Range(1,3); // always spawn an obstacle
		bool isDoubleJumpBlock = false;
        
		// Single block
		if(i == 1)
		{
			singleBlock.GetComponent<BankObject>().MoveTo(obstacleLocation.position);
		}
		// Double jump block
		else
		{
			doubleJumpBlock.GetComponent<BankObject>().MoveTo(obstacleLocationDoubleJump.position);
			isDoubleJumpBlock = true;
		}
		// No obstacle
		//else{}

		return isDoubleJumpBlock;
	}

	void SpawnLoinBeforeObstacle(bool isDoubleJumpBlock)
	{
		// If it's a single jump block, lets not do an arc
		int i;
		if(isDoubleJumpBlock)		
			i = Random.Range(1,3);		
		else
			i = Random.Range(1,2);


		// Spawn a row
		if(i == 1)
		{
			LoinSpawner.Instance.CreateRow(loinLocation_beforeObstacleRow.position);
		}
		// Spawn an arc 
		else if(i == 3) // 3 so we can exclude it easily
		{
			LoinSpawner.Instance.CreateArc(loinLocation_beforeObstacleArc.position, true);
		}
		// Spawn nothing
		else{}
	}

	void SpawnLoinAfterObstacle(bool isDoubleBlock)
	{
		// Double block we can only spawn a straight line OR nothing
		if(isDoubleBlock)
		{
			if(Random.Range(1,2) == 1)
			{
				LoinSpawner.Instance.CreateRow(loinLocation_doubleJump.position);
			}
			else{}
		}
		else
		{

			CreateRandomLoinPattern(loinLocation_jump.position);
		}
        
	}

	void CreateRandomLoinPattern(Vector2 position)
	{
		int i = Random.Range(1,3);

		// Quarter circle
		if(i == 1)
		{
			LoinSpawner.Instance.CreateArc(position, true);
		}
		// Semi circle
		/*else if(i == 2)
		{
			loinSpawner.CreateArc(position, false);
		}*/
		// Straight line
		else if(i == 2)
		{
			LoinSpawner.Instance.CreateRow(position);
		}
		// Spawn nothing
		else{}

	}







}
