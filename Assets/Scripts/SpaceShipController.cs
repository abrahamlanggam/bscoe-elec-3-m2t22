using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour {
	Rigidbody _rigidbody;
	public int speed = 80; //8 for nomer's
	public float gravity =50f;
	public enum spaceShip {Ship1, Ship2};

	public spaceShip ShipSelect;
	public ParticleSystem fireParticle;
	bool thrusting=false;
	AudioSource takeoff;

	Respawner collideOff;
	bool collide=true;
	float soundCharge=0f;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody>();
		takeoff = gameObject.GetComponent<AudioSource> ();
		//collideOff=gameObject.GetComponent<Respawner> ();
		//clip= gameObject.GetComponent<AudioClip> ();
	}

	void Update () {
		
		if (Input.GetKeyDown (KeyCode.O)) {
			collide = !collide;
			CollideOff (collide);
			Debug.Log ("Collision OFF");
		}

		takeoff.volume = (soundCharge);
		if (ShipSelect == spaceShip.Ship1) {
			ShipOne ();
		}else if (ShipSelect == spaceShip.Ship2) {
			ShipTwo ();
		}

		if(thrusting)
		{
			if (soundCharge <= 1f) {
				soundCharge+=.05f;
			}

			//takeoff.Play ();
			if(!fireParticle.GetComponent<ParticleSystem>().isPlaying)
			{
				fireParticle.GetComponent<ParticleSystem>().Play();
			}
		}else{
			if (soundCharge >= 0f) {
				soundCharge-=.05f;
			}


			//takeoff.Stop ();
			if(fireParticle.GetComponent<ParticleSystem>().isPlaying)
			{
				fireParticle.GetComponent<ParticleSystem>().Stop();

			}
		}

	}


	private void ShipOne()
	{
		if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.W)) {
			if (_rigidbody.velocity.magnitude > 10) {
				_rigidbody.velocity = _rigidbody.velocity.normalized * 10;
			}
			_rigidbody.AddRelativeForce ((Vector3.up * Time.deltaTime) * gravity);

			thrusting = true;
		}else {
			thrusting = false;
			//			
		} 

		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(Vector3.forward * speed * Time.deltaTime);

		}
		else if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
		}
	}



	private void ShipTwo()
	{
		if( Input.GetKey(KeyCode.UpArrow))
		{
			if (_rigidbody.velocity.magnitude > 10)
			{
				_rigidbody.velocity = _rigidbody.velocity.normalized * 10;
			}
			_rigidbody.AddRelativeForce((Vector3.up * Time.deltaTime) * gravity);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(Vector3.forward * speed * Time.deltaTime);

		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
		}
	}

	void CollideOff(bool col){
		GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag ("stars");

		foreach(GameObject go in gameObjectArray)
		{
			go.GetComponent<Collider> ().enabled = col;

		}
	}



}
