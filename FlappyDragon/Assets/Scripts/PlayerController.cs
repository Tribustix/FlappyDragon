using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D playerRigidBody2D;
	public float upForce = 200f;
	private float rotationSpeedLimit = 10f;
	private float maxAngleToRotate = 30f;
	private float angle;
	

	private void Start () {
		playerRigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	private void Update () {
		
		float calculateTime = playerRigidBody2D.velocity.y / rotationSpeedLimit;

		if(Input.GetMouseButtonDown(0)){

			if(!GameManager.Instance.IsGameActive){
				GameManager.Instance.StartGame();
				playerRigidBody2D.gravityScale = 1f;
			}

			playerRigidBody2D.velocity = Vector2.zero;
			playerRigidBody2D.AddForce(new Vector2(0, upForce));
		}

		if(playerRigidBody2D.velocity.y >=0f){
			angle = Mathf.Lerp(0, maxAngleToRotate, calculateTime);
		}else{
			angle = Mathf.Lerp(0, -maxAngleToRotate, -calculateTime);
		}
		
		playerRigidBody2D.MoveRotation(angle);
	}

private void OnCollisionEnter2D(Collision2D collision) {
	GameManager.Instance.GameOver();
}


}
