using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EJ_Almanac_Open_Image_Button : MonoBehaviour {

	public GameObject inviDescription1;
	public GameObject inviDescription2;
	public GameObject inviDescription3;

    void Start() {
        
    }

	public void ShowImageDescription (){
			
		inviDescription1.SetActive (true);
		inviDescription2.SetActive (true);
		inviDescription3.SetActive (false);

	}
}
