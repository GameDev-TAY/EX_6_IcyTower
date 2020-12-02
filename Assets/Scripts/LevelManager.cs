using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

	public Transform player;
	public CameraMovement mainCamera;

	[Header("Vertical Walls")]
	[SerializeField] GameObject wallsPrefabLevel1;
	[SerializeField] GameObject wallsPrefabLevel2;
	[SerializeField] GameObject wallsPrefabLevel3;
	[SerializeField] GameObject wallsPrefabLevel4;
	public float currentWallY;
	[SerializeField] float wallTall = 11.5f;
	[SerializeField] float distanceBeforeSpawn = 10f;
	[SerializeField] int initialWalls = 6;
	public List<GameObject> wallPoolLevel1;
	public List<GameObject> wallPoolLevel2;
	public List<GameObject> wallPoolLevel3;
	public List<GameObject> wallPoolLevel4;

	[Header("Platforms")]
	[SerializeField] GameObject blockPrefabLevel1;
	[SerializeField] GameObject blockPrefabLevel2;
	[SerializeField] GameObject blockPrefabLevel3;
	[SerializeField] GameObject blockPrefabLevel4;
	public float currentBlockY;
	[SerializeField] float distanceBetweenBlocks = 2f;
	[SerializeField] float distanceBeforeSpawnBlock = 10f;
	[SerializeField] int initBlocksLine = 10;
	public List<GameObject> blocksPoolLevel1;
	public List<GameObject> blocksPoolLevel2;
	public List<GameObject> blocksPoolLevel3;
	public List<GameObject> blocksPoolLevel4;


	public float countWalls = 0;


	/**The function initializes the pool of walls and blocks we will use**/
	private void Awake()
	{
		InitVerticalWalls();
		InitBlocks();
	}

	/**The function checks in each frame whether additional walls and blocks need to be spawned**/
	private void Update()
	{

		countWalls = player.position.y;

		if (currentWallY - player.position.y < distanceBeforeSpawn)
		{
			SpawnVerticalWall();
		}

		if (currentBlockY - player.position.y < distanceBeforeSpawnBlock)
		{
			SpawnBlocks();
		}

		if (countWalls >= 0 && countWalls < 10)
		{
			mainCamera.speedMultiple = 5f;

		}


	}

	/**The function triggers the production of the walls**/
	private void InitVerticalWalls()
	{
		InitVerticalWallsBywallsPrefabLeve(wallsPrefabLevel1, wallPoolLevel1);
		InitVerticalWallsBywallsPrefabLeve(wallsPrefabLevel2, wallPoolLevel2);
		InitVerticalWallsBywallsPrefabLeve(wallsPrefabLevel3, wallPoolLevel3);
		InitVerticalWallsBywallsPrefabLeve(wallsPrefabLevel4, wallPoolLevel4);
	}

	/**The function triggers the production of the blocks**/
	private void InitBlocks()
	{
		InitBlocksByblockPrefabLevel(blockPrefabLevel1, blocksPoolLevel1);
		InitBlocksByblockPrefabLevel(blockPrefabLevel2, blocksPoolLevel2);
		InitBlocksByblockPrefabLevel(blockPrefabLevel3, blocksPoolLevel3);
		InitBlocksByblockPrefabLevel(blockPrefabLevel4, blocksPoolLevel4);
	}

	/**The function produces 6 walls from the model it receives and attaches them to the appropriate list**/
	private void InitVerticalWallsBywallsPrefabLeve(GameObject wallsPrefabLevel, List<GameObject> wallPoolLevel)
	{
		for (int i = 0; i < initialWalls; ++i)
		{
			Vector2 pos = new Vector2(0, currentWallY);
			GameObject go = Instantiate(wallsPrefabLevel, pos, Quaternion.identity, transform);
			wallPoolLevel.Add(go);
			currentWallY += wallTall;
		}
	}

	/**The function produces 6 blocks from the model it receives and attaches them to the appropriate list**/
	private void InitBlocksByblockPrefabLevel(GameObject blockPrefabLevel, List<GameObject> blocksPoolLevel)
	{
		for (int i = 0; i < initBlocksLine; i++)
		{
			Vector2 pos = new Vector2(Random.Range(-10, 10), currentBlockY);
			GameObject go = Instantiate(blockPrefabLevel, pos, Quaternion.identity, transform);
			blocksPoolLevel.Add(go);
			currentBlockY += distanceBetweenBlocks;
		}
	}

	/**A function calls a spawning function according to the correct prefab of the level - for the vertical wall  **/
	private void SpawnVerticalWall()
	{
		if (countWalls >= 0 && countWalls < 10)
		{
			SpawnVerticalWallByPrefabLevel(wallPoolLevel1);
		}
		else if (countWalls >= 10 && countWalls < 20)
		{
			SpawnVerticalWallByPrefabLevel(wallPoolLevel2);
		}
		else if (countWalls >= 20 && countWalls < 30)
		{
			SpawnVerticalWallByPrefabLevel(wallPoolLevel3);
		}
		else
		{
			SpawnVerticalWallByPrefabLevel(wallPoolLevel4);
		}

	}

	/**A function calls a spawning function according to the correct prefab of the level - for the blocks**/
	private void SpawnBlocks()
	{
		if (countWalls >= 0 && countWalls < 10)
		{
			SpawnBlocksByPrefabLevel(blocksPoolLevel1);
		}
		else if (countWalls >= 10 && countWalls < 20)
		{
			SpawnBlocksByPrefabLevel(blocksPoolLevel2);
		}
		else if (countWalls >= 20 && countWalls < 30)
		{
			SpawnBlocksByPrefabLevel(blocksPoolLevel3);
		}
		else
		{
			SpawnBlocksByPrefabLevel(blocksPoolLevel4);

		}

	}
	/**The function spawns according to the type it has in the list - for the vertical wall**/
	private void SpawnVerticalWallByPrefabLevel(List<GameObject> wallPoolLevel)
	{
		wallPoolLevel[0].transform.position = new Vector2(0, currentWallY);
		currentWallY += wallTall;

		GameObject temp = wallPoolLevel[0];
		wallPoolLevel.RemoveAt(0);
		wallPoolLevel.Add(temp);
		countWalls++;
	}

	/**The function spawns according to the type it has in the list- for the blocks**/
	private void SpawnBlocksByPrefabLevel(List<GameObject> blocksPoolLevel)
	{
		blocksPoolLevel[0].transform.position = new Vector2(Random.Range(-10, 10), currentBlockY);
		currentBlockY += distanceBetweenBlocks;

		GameObject temp = blocksPoolLevel[0];
		blocksPoolLevel.RemoveAt(0);
		blocksPoolLevel.Add(temp);
	}

}