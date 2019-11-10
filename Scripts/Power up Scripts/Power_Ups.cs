using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script Summary 
// This script will be responsible for controlling thre time mechanics for each power_up;

public class Power_Ups : MonoBehaviour
{
	// Shield value timer
	public float Shield_Timer;
	// Multiplier value timer
	public float Multiplier_Timer;
	// Slow Down Time value timer
	public float SlowTime_Timer;

	[Space]

	// This will enable other Power_Ups Inactive while one is currently active
	public bool PowerUpActive = false;

	public void Shields()
	{
		if(PowerUpActive == true)
		{
			StartCoroutine(Shield_Timer_Control());
		}
	}
	public void Multiplier()
	{
		if(PowerUpActive == true)
		{
			StartCoroutine(Multiplier_Timer_Control());
		}
	}
	public void SlowTime()
	{
		if(PowerUpActive == true)
		{
			StartCoroutine(SlowTime_Timer_Control());
		}
	}



	IEnumerator Shield_Timer_Control()
	{
		// Disable Other Power_Up Functionalities
		PowerUpActive = false;

		// Enable Shield

		yield return new WaitForSeconds(Shield_Timer);

		// Disable Shield

		// Now Enable Other Ups
		PowerUpActive = true;
	}



	IEnumerator Multiplier_Timer_Control()
	{
		// Disable Other Power_Up Functionalities
		PowerUpActive = false;

		// Enable Score Multiplier

		yield return new WaitForSeconds(Multiplier_Timer);

		// Disable Multiplier

		// Now Enable Other Ups
		PowerUpActive = true;
	}



	IEnumerator SlowTime_Timer_Control() // <-- Test First
	{
		// Disable Other Power_Up Functionalities
		PowerUpActive = false;

		// Enable Time Slows to a crawl
		Time.timeScale = 0.5f;

		yield return new WaitForSecondsRealtime(SlowTime_Timer);

		// Enable Deja_Vu!!
		Time.timeScale = 1.0f;

		// Now Enable Other Ups
		PowerUpActive = true;
	} 


}
