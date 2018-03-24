using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {


	private float obstaclesVelocity = -3f;
	private float obstaclesDistance = 11f;


	
	void Update () {
		
		transform.position += new Vector3(obstaclesVelocity * Time.deltaTime, 0f, 0f);

		if(transform.position.x < -7f){
			transform.position = setObstacle();
		}
	}

	private Vector3 setObstacle(){
		Vector3 temporalPosition = transform.position + (new Vector3(obstaclesDistance,0f,0f));
		temporalPosition.y = Random.Range(4.17f, 8f);
		return temporalPosition;
	}
}
