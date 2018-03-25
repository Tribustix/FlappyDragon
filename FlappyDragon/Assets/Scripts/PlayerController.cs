using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D playerRigidBody2D;
	public float upForce = 200f;
	private float rotationSpeedLimit = 10f;
	private float maxAngleToRotate = 30f;
	private float angle;
	private Animator anim;

	private void Start () {
		playerRigidBody2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		anim.SetBool("PlayerMoving", true);
	}
	
	private void Update () {
		
		float calculateTime = playerRigidBody2D.velocity.y / rotationSpeedLimit;

		if(Input.GetMouseButtonDown(0) && !GameManager.Instance.gameOver){

			if(!GameManager.Instance.IsGameActive){
				GameManager.Instance.StartGame();
				playerRigidBody2D.gravityScale = 1f;
			}

			anim.SetBool("PlayerMoving", true);
			playerRigidBody2D.velocity = Vector2.zero;
			playerRigidBody2D.AddForce(new Vector2(0, upForce));
		}

		if(Input.GetMouseButtonUp(0)){
			anim.SetBool("PlayerMoving", false);
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
