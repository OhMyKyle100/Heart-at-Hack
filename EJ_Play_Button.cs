using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EJ_Play_Button : MonoBehaviour {

	void Update () {

	}

	public void ShowGame(){

		SceneManager.LoadScene("Level_Demo");

	}
}
