using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EJ_Trivia_Button : MonoBehaviour {

	void Update () {

	}

	public void ShowTrivia(){

		SceneManager.LoadScene("HeartAtHackTrivia");

	}
}
