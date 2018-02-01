using UnityEngine;
using System.Collections;

public class FollowScript : MonoBehaviour {
	// written by herman darr july 20 2014 6:12PM
	public Transform playerToFollow;
//	public Transform wallLeft;
//	public Transform wallRight;
//	public Transform destroyer;
	float lastHigh;
	public bool CanGoDown=false;

	void Start(){
		lastHigh = playerToFollow.position.y;
	}
	void Update () {
		if(playerToFollow)
		{
			Vector3 newPosition = transform.position;
			newPosition.y = playerToFollow.position.y;

			if (CanGoDown) {
					transform.position = newPosition;
			
			} else {
				if (newPosition.y >= lastHigh) {
					transform.position = newPosition;
					//				wallLeft.position=new Vector3(wallLeft.position.x,newPosition.y,wallLeft.position.z);
					//				wallRight.position=new Vector3(wallRight.position.x,newPosition.y,wallRight.position.z);
					//				destroyer.position=new Vector3(destroyer.position.x,destroyer.transform.position.y+newPosition.y,destroyer.position.z);
				}
			}


			if (lastHigh <= transform.position.y) {
				lastHigh= transform.position.y;

			}

			//Debug.Log ("current: "+transform.position.y +" last: " +lastHigh);
			//Transform.LookAt(0,newPosition.y,0);
		}
	}

	public void ResetCamera(){
		transform.position=new Vector3(transform.position.x,0,transform.position.z);
		lastHigh = transform.position.y;

	}

}