using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
	public float LeftSpawnValue;
	public float RightSpawnValue;
	[Space]
	//Random Objects that are prefab'd as to be used to randomly spawn
	public GameObject[] Obstacle_Objects;
	[Space]
	public int ObjectAmountIndex = 5;

	// Update is called once per frame
	void Update()
	{
		/*
		if(Input.GetKeyDown(KeyCode.Space))
		{
			SpawnAnEnemy();
		}
		*/
	}

	public void SpawnAnEnemy()
	{
		// Gets this GameObject Vector position, based on this object transform position 
		Vector3 SpawnPosition = this.transform.position;

		// Randomizes the Positon of the Mid and max vlaue of the X-Axis
		SpawnPosition.x = Random.Range(LeftSpawnValue,RightSpawnValue);

		// Then Spawns A
		Instantiate(Obstacle_Objects[Random.Range(0,ObjectAmountIndex)],SpawnPosition,transform.rotation);
	}
}
