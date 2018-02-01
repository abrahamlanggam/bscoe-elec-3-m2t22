using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetPadScript : MonoBehaviour {


	int rand;
	public Transform ship1;

	float dist1;
	float dist2;
	public float distanceNeed=50f;
	AudioSource winSound;
	public Animator anim;


	public GameObject otherPlatform;
	// Use this for initialization
	void Start () {
		winSound = gameObject.GetComponent<AudioSource> ();
		anim = anim.GetComponent<Animator> ();
//		rand=Random.Range(0,skyBoxes.Length);
//		RenderSettings.skybox =skyBoxes[rand];  
	}

	// Update is called once per frame
	void Update () {

		dist1 = Vector3.Distance(ship1.transform.position, transform.position);

		//Debug.Log ("dist1: "+dist1 + "  dist2: "+dist2);

		if (dist1 <= distanceNeed) {
			Ship1Detect ();
		}  
			else {
			gameObject.GetComponent<Renderer> ().material.color=Color.black;
			otherPlatform.gameObject.GetComponent<Renderer> ().material.color=Color.black;
		}
	}


	void OnCollisionEnter(Collision col){
		Debug.Log (col.gameObject.name);

		if (col.gameObject.tag == "spaceship") {
			winSound.Play ();
			anim.SetTrigger("nextScene");
			//col.gameObject.GetComponent<Respawner> ().Invoke("Respawn",2f);

			Debug.Log ("Finish");

			Invoke("NextLevel",2);

//			if (rand < skyBoxes.Length-1) {
//				rand++;
//			} else {
//				rand = 0;
//			}
//			RenderSettings.skybox = skyBoxes [rand];	

		}
	}

	void Ship1Detect(){
		gameObject.GetComponent<Renderer> ().material.color=Color.white;
		otherPlatform.gameObject.GetComponent<Renderer> ().material.color = Color.white;

	}

	void NextLevel(){
		int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
		if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
			{
				SceneManager.LoadScene(nextSceneIndex);
			}
	}
}





	

