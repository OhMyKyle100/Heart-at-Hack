using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EJ_Rewards_Button : MonoBehaviour {

	void Update () {

	}

	public void ShowRewards(){

		SceneManager.LoadScene("HeartAtHackRewards");

	}
}
