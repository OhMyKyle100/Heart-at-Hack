using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public Animator anim_wave;


	// User Interface Components
	public Slider slider;
	public Text ScoreText;
	public Text WaveText; 
	public Text FinalResults;

	// Player Health Value
	public float Player_Health = 0f;
	public float Player_MaxHealth = 100f;
	public float IntervalPerSpawn = 0.5f;

	[Space]

	public int Waves = 0;
	public int EvadedOppositions = 0;
	public int NextWaveMilestone = 10;
	public int NumberOfEnemiesPerWaves;
	public int ScoreValue;

	[Space]

	[Header("Form Variants")]

	[Space]
	public GameObject First_Form;
	public GameObject Second_Form;
	public GameObject Third_Form;

	[Space]

	public GameObject Warning_UI;
	public GameObject EndGame_UI;

	public GameObject PlayerGameObject;

	[Space]

	public bool StopTimeOnce = true;
	public bool StopTimeOnce_Two = true;





	void Start()
	{
		// Disables the Ui for Warning about the Damage;
		Warning_UI.SetActive(false);

		// Disables the Lose UI with rewards
		EndGame_UI.SetActive(false);

		Waves += 1;

		StartCoroutine(New_Wave());
	}



	public void YouDied()
	{
		StopTimeOnce_Two = false;
		EndGame_UI.SetActive(true);
		Time.timeScale = 0f;
	}

	public void BackToMainMenu()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(0);
	}
	public void Restart()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(1);
	}



	// For the Player to continue the game, 
	public void ContinueGame()
	{
		Time.timeScale = 1.0f;
		// Enables the Ui for Warning about the Damage;
		Warning_UI.SetActive(false);
	}
	// For Enabling th Warning Display of the Player Upon Detection
	public void WarningUIDisplay()
	{
		StopTimeOnce = false;

		Warning_UI.SetActive(true);

		Time.timeScale = 0f;
	}




	// This Method is for shifting the look of the Player Object
	private void FormShifting (bool FirstForm,bool SecondForm,bool ThirdForm)
	{
		if(FirstForm == true)
		{
			First_Form.SetActive(true);
			Second_Form.SetActive(false);
			Third_Form.SetActive(false);
		}
		if(SecondForm == true)
		{
			First_Form.SetActive(false);
			Second_Form.SetActive(true);
			Third_Form.SetActive(false);
		}
		if(ThirdForm == true)
		{
			First_Form.SetActive(false);
			Second_Form.SetActive(false);
			Third_Form.SetActive(true);
		}
	}

	// Update is called once per frame
	void Update()
	{
		FinalResults.text = "Pts. " + ScoreValue.ToString();

		WaveText.text = "Day " + Waves.ToString();

		ScoreText.text = ScoreValue.ToString();

		slider.value = Player_Health/Player_MaxHealth;

		// These Player Healths are responsible for the changing of the player avatar

		/*
		if(Player_Health > 50f && Player_Health < 100)
		{
			FormShifting(true,false,false);
		}

		if(Player_Health > 25f && Player_Health < 50f )
		{
			FormShifting(false,true,false);
		}
		
		if(Player_Health > 0f && Player_Health < 25f)
		{
			FormShifting(false,false,true);
		}
		*/

		if(Player_Health > 75f)
		{
			FormShifting(true,false,false);
		}

		if(Player_Health > 45f && Player_Health < 75f)
		{
			FormShifting(false,true,false);
		}

		if(Player_Health < 25f)
		{
			FormShifting(false,false,true);
		}



		if(StopTimeOnce == true)
		{
			if(Player_Health < 75f)
			{
				WarningUIDisplay();
			}
		}

		if(StopTimeOnce_Two == true)
		{
			if(Player_Health <= 0)
			{
				YouDied();

			}
		}


		if(Player_Health > 100f)
		{
			Player_Health = 100f;
		}

		if(Player_Health < 0f)
		{
			Player_Health = 0f;
		}





		// If the player reached a certain milestone
		if(EvadedOppositions >= NextWaveMilestone)
		{
			// Reset the Evaded Oppositions
			EvadedOppositions = 0;
			//Increment The Next Milestone to be incremented
			NextWaveMilestone += 5;
			// Set to the Next Wave
			Waves += 1;
			// Begin the Actual Next Wave
			StartCoroutine(New_Wave());
		}


	}

		

	IEnumerator New_Wave()
	{
		anim_wave.SetTrigger("Wave_IN");
		
		yield return new WaitForSeconds(3f);

		anim_wave.SetTrigger("Wave_STATIC");

		// Give Player
		yield return new WaitForSeconds(1f);

		// Spawn the Next Wave
		WaveManager();

	}

	public void WaveManager()
	{
		if(Waves == 1)
		{
			
			StartCoroutine(Wave_One());
		}
		if(Waves == 2)
		{
			
			StartCoroutine(Wave_Two());
		}
		if(Waves == 3)
		{
			
			StartCoroutine(Wave_Three());
		}

		if(Waves == 4)
		{
			StartCoroutine(Wave_Four());
		}
	}

	IEnumerator Wave_One()
	{
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();

		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();

		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();

		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();

		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();

		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();

		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();

		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();

		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();

		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
	}

	IEnumerator Wave_Two()
	{
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
	}

	IEnumerator Wave_Three()
	{
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.5f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(1f);

		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();

		yield return new WaitForSeconds(0.5f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();

		yield return new WaitForSeconds(1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();

		yield return new WaitForSeconds(0.5f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();

		yield return new WaitForSeconds(1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();

		yield return new WaitForSeconds(0.5f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();

		yield return new WaitForSeconds(1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
	}


	IEnumerator Wave_Four()
	{
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("Opposition_Spawner").GetComponent<Enemy_Spawner>().SpawnAnEnemy();
		yield return new WaitForSeconds(0.1f);
	}

	public void TakeDamage()
	{
		Player_Health -= 25f; //Random.Range(0f,5f);
	}

	public void GiveHealth()
	{
		Player_Health +=  25f; //Random.Range(0f,5f);
	}
}
