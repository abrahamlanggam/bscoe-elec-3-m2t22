using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
	GameObject collide;
	public GameObject SpaceShipPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "spaceship") {
			col.gameObject.GetComponent<Respawner> ().Respawn();
	


		}
	}




}
