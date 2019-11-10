using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EJ_Almanac_Close_Image_Button : MonoBehaviour {

	public GameObject inviDescription1;
	public GameObject inviDescription2;
	public GameObject inviDescription3;

	void Start() {

	}

	public void CloseImageDescription (){

		inviDescription1.SetActive (false);
		inviDescription2.SetActive (false);
		inviDescription3.SetActive (true);

	}
}
