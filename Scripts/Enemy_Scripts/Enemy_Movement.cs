using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
	public float RandomizedSpeed;

	void Awake()
	{
		RandomizedSpeed = Random.Range(3f,5f);
	}

	// Update is called once per frame
	void Update()
	{
		float DescentValue = -RandomizedSpeed * Time.deltaTime;

		this.gameObject.transform.Translate(0,DescentValue,0); 
	}

	// When this Enemy Dissapeared on Screen
	void OnBecameInvisible()
	{
		// Print out on console that this Object is destroyed
		Debug.Log("Object Dissapeared");

		// Destroy this gameObject
		Destroy(this.gameObject);
	}

}
