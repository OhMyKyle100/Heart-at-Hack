using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Boundary : MonoBehaviour
{
	public float MinX;
	public float MaxX;
	public float MinY;
	public float MaxY;


	// Update is called once per frame
	void Update()
	{
		// Gets the players current position
		Vector3 PlayerPosition = transform.position;

		// Locks the Player in world coordinates in Z-Axis
		PlayerPosition.z = 0f; 

		// Locks this objects position in the X-Axis based on Min and Max X value
		PlayerPosition.x = Mathf.Clamp(PlayerPosition.x,MinX,MaxX);

		// Locks this objects position in the X_Axis based on Min and Max
		PlayerPosition.y = Mathf.Clamp(PlayerPosition.y,MinY,MaxY);

		// Then Sets this objects position, based on the Player position Vector Initializations
		transform.position = PlayerPosition;

	}
}
