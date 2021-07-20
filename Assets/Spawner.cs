using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject[] crateTypes;
	public Transform[] spawnpoints;

	public float timeBetweenSpawns;
	public float waitTimeDecrease;
	public float minWaitTime;

	public bool isEnabled;

	private void Start()
	{
		SpawnCrate();
	}

	public void SpawnCrate() 
	{
		if (isEnabled)
		{
			int crateType = Random.Range(0, crateTypes.Length);
			int spawnpoint = Random.Range(0, spawnpoints.Length);
			Vector3 dir = new Vector3(0, 0, 1);

			if (spawnpoint > 2)
			{
				dir = new Vector3(0, 0, -1);
			}

			GameObject crate =
				Instantiate(crateTypes[crateType], spawnpoints[spawnpoint].position, Quaternion.identity);
			crate.GetComponent<CrateMover>().dir = dir;

			StartCoroutine(WaitForNextSpawn());
		}
	}

	public IEnumerator WaitForNextSpawn() 
	{
		yield return new WaitForSeconds(timeBetweenSpawns);

		if((timeBetweenSpawns-waitTimeDecrease) > minWaitTime)
			timeBetweenSpawns -= waitTimeDecrease;

		SpawnCrate();
	}
}
