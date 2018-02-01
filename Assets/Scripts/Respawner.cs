using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour {
	public GameObject SpaceShipPrefab;
	Vector3 originalPos;
	Quaternion originalRot;
	AudioSource source;
	public AudioClip clip;

	// Use this for initialization
	void Start () {
		originalPos = SpaceShipPrefab.transform.position;
		originalRot = SpaceShipPrefab.transform.rotation;

		source= gameObject.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision col){
		Debug.Log (col.gameObject.name);

		if (col.gameObject.tag == "stars") {
			source.PlayOneShot (clip);
			foreach(Collider c in gameObject.GetComponents<Collider>()){
				c.enabled = false;
			}
			 
			gameObject.GetComponent<SpaceShipController> ().enabled = false;
			Invoke ("Respawn", 2);

		}
	}

	public void Respawn(){

		FollowScript follow = FindObjectOfType<FollowScript> ().GetComponent<FollowScript> ();
		follow.ResetCamera ();

		transform.position = originalPos;
		transform.rotation = originalRot;
		foreach(Collider c in gameObject.GetComponents<Collider>()){
			c.enabled = true;
		}
		gameObject.GetComponent<SpaceShipController> ().enabled = true;
	}

}

