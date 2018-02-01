// Floater v0.0.2
// by Donovan Keith
//
// [MIT License](https://opensource.org/licenses/MIT)

using UnityEngine;
using System.Collections;

// Makes objects float up & down while gently spinning.
public class Floater : MonoBehaviour {
	// User Inputs
	public float degreesPerSecond = 15.0f;
	public float amplitude = 0.5f;
	public float frequency = 1f;
	public bool random=false;

	float rand;
	float randfreq;
	Quaternion randrot;

	// Position Storage Variables
	Vector3 posOffset = new Vector3 ();
	Vector3 tempPos = new Vector3 ();
	public bool horizontal=false;


	// Use this for initialization
	void Start () {
		if (random) {
			randrot=new Quaternion(Random.Range(0,360),Random.Range(0,360),Random.Range (0,360),0);
			rand = Random.Range (0,amplitude);
			randfreq = Random.Range (0,frequency);
			transform.rotation = randrot;
		}

		// Store the starting position & rotation of the object
		posOffset = transform.position;

	}

	// Update is called once per frame
	void Update () {
		// Spin object around Y-Axis
		transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

		// Float up/down with a Sin()
		if(random){
			amplitude = rand;
			frequency = randfreq;
		}


		if (horizontal) {
			tempPos = posOffset;
			tempPos.x += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;

		}else{
			tempPos = posOffset;
			tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;

		}

		transform.position = tempPos;
	}
}
