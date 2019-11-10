using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles_Disposal : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("Enemy"))
		{

			GameObject.Find("GameManager").GetComponent<GameManager>().EvadedOppositions += 1;

			Destroy(col.gameObject);
		} 


		if(col.gameObject.CompareTag("PowerUps"))
		{
			GameObject.Find("GameManager").GetComponent<GameManager>().EvadedOppositions += 1;

			Destroy(col.gameObject);
		} 

	}


}
