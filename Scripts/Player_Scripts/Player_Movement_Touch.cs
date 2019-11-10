using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Touch : MonoBehaviour
{
	public float touchX,touchY;
	private Rigidbody rb;

	// Tutorial Variables

	public Animator anim_Tutorial;
	public bool TutorialAspect;

	// Obstacle Tags

	[Header("Names of Enemies")]
	public string[] Enemy_names;

	[Space]

	[Header("Names of Beneficiaries")]
	public string[] PowerUp_names;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void TutorialTouch_Enabled()
	{
		Time.timeScale = 0f;
		anim_Tutorial.SetTrigger("Tutorial_TouchControls");
		TutorialAspect = true;
	}

	public void TutorialTouch_Disabled()
	{
		Time.timeScale = 1f;
		anim_Tutorial.SetTrigger("Tutorial_Static");
		TutorialAspect = false; 
	}

	// Update is called once per frame
	void Update()
	{

		if(Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			Vector3 TouchPosition = Camera.main.ScreenToWorldPoint(touch.position);

			TouchPosition.z = 0f;

			if(Input.GetTouch(0).phase == TouchPhase.Began)
			{

				if(TutorialAspect == true)
				{
					TutorialTouch_Disabled();
				}

				touchX = TouchPosition.x - transform.position.x;
				touchY = TouchPosition.y - transform.position.y;
			}
			if(Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				rb.MovePosition(new Vector3(TouchPosition.x - touchX,TouchPosition.y - touchX,0));
			}
			if(Input.GetTouch(0).phase == TouchPhase.Ended)
			{
				rb.velocity = Vector3.zero;
			}

		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag(Enemy_names[0]))
		{

			// Calls the GameObject that this object hit the player, and regardless, adds a point to the GameManagers EvadedOppositions variable
			GameObject.Find("GameManager").GetComponent<GameManager>().EvadedOppositions += 1;

			// Notify the GameManager that the player took damage
			GameObject.Find("GameManager").GetComponent<GameManager>().TakeDamage();
			// Destroys the Collided GameObject
			Destroy(col.gameObject);
		}


		if(col.gameObject.CompareTag(PowerUp_names[0]))
		{
			// Calls the GameObject that this object hit the player, and regardless, adds a point to the GameManagers EvadedOppositions variable
			GameObject.Find("GameManager").GetComponent<GameManager>().EvadedOppositions += 1;

			// Give Player Points
			GameObject.Find("GameManager").GetComponent<GameManager>().ScoreValue += (Random.Range(5,25));

			// Notify the GameManager that the player took damage
			GameObject.Find("GameManager").GetComponent<GameManager>().GiveHealth();
			
			// Destroys the Collided GameObject
			Destroy(col.gameObject);
		}
	}
}
