using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {


	private float obstaclesVelocity = -4f;
	private float obstaclesDistance = 11f;


	
	private void Update () {

		if(GameManager.Instance.IsGameActive){
			transform.position += new Vector3(obstaclesVelocity * Time.deltaTime, 0f, 0f);

			if(transform.position.x < -7f){
				transform.position = setObstacle();
			}
		}
	}	

	private Vector3 setObstacle(){
		Vector3 temporalPosition = transform.position + (new Vector3(obstaclesDistance,0f,0f));
		temporalPosition.y = Random.Range(4.17f, 8f);
		return temporalPosition;
	}
}
