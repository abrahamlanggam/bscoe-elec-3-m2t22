using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.R)) {
			Debug.Log ("restart");
			NextLevel ();
		}
	}

	void NextLevel(){
		
			SceneManager.LoadScene(0);
		
	}
}
