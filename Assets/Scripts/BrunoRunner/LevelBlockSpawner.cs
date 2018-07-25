using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LevelBlockSpawner : MonoBehaviour {

	// Singleton
	public static LevelBlockSpawner Instance;

	// Level blocks
	public List<LevelBlock> blocks;
	private int nrBlocksUnused;

	public GameObject player;
	public bool isSpawnLevel = false;
	public bool isFirstSpawn = true;
	public float firstSpawnDistanceFromPlayer = 20f;

	void Awake()
	{
		if(Instance != null)
		{
			Debug.LogError("Multiple instances of LevelBlockSpawner");
		}

		Instance = this;
	}

	void Start()
	{
		nrBlocksUnused = blocks.Count;
	}
	
	void Update () 
	{
		if(isFirstSpawn && isSpawnLevel)
		{
			isFirstSpawn = false;

			SpawnNewBlock(new Vector2(player.transform.position.x + firstSpawnDistanceFromPlayer, 0));
		}
	}

	public void SpawnNewBlock(Vector2 position)
	{
		if(isSpawnLevel && nrBlocksUnused != 0)
		{
			int i = Random.Range(0, nrBlocksUnused - 1);
			LevelBlock blockToSpawn = blocks.ElementAt(i);
			blockToSpawn.MoveBlock(position, true);
			blocks.Remove(blockToSpawn);
			nrBlocksUnused--;
			blocks.Add (blockToSpawn);
		}
	}

	public void AddUnusedBlock(LevelBlock block)
	{
		nrBlocksUnused++;
	}
}
