using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_WASD : MonoBehaviour
{
	public float speed;
	[Space]

	[Header("Names of Enemies")]
	public string[] Enemy_names;

	[Space]

	[Header("Names of Beneficiaries")]
	public string PowerUp_names;



	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		// The Transform of the gameObject
		Vector3 PlayerPosition = transform.position;

		float x_Move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float y_Move = Input.GetAxis("Vertical") * speed * Time.deltaTime;

		// Constraints the z position of this gameObject
		PlayerPosition.z = 0f;

		transform.Translate(x_Move,y_Move,0f);
	}

}
