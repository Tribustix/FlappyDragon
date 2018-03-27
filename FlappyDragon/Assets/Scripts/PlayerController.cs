﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D playerRigidBody2D;
	public float upForce = 200f;
	private float rotationSpeedLimit = 10f;
	private float maxAngleToRotate = 30f;
	private Animator anim;

	private void Start () {
		playerRigidBody2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		anim.SetBool("PlayerMoving", true);
	}
	
	private void Update () {
		
		float fallTime = playerRigidBody2D.velocity.y / rotationSpeedLimit;

		if(Input.GetMouseButtonDown(0) && !GameManager.Instance.gameOver){

			if(!GameManager.Instance.IsGameActive){
				GameManager.Instance.StartGame();
				StartGravity(1f);
			}
			anim.SetBool("PlayerMoving", true);
			PlayerJump();
		}

		if(Input.GetMouseButtonUp(0)){
			anim.SetBool("PlayerMoving", false);
		}

		playerRigidBody2D.MoveRotation(RecalculateAnglePlayer(fallTime));
	}

private void OnCollisionEnter2D(Collision2D collision) {
	GameManager.Instance.GameOver();
}

private void PlayerJump(){
	playerRigidBody2D.velocity = Vector2.zero;
	playerRigidBody2D.AddForce(new Vector2(0, upForce));
}

private void StartGravity(float gravity){
	playerRigidBody2D.gravityScale = gravity;
}

private float RecalculateAnglePlayer(float time){
	float angle;
	if(playerRigidBody2D.velocity.y >=0f){
		return angle = Mathf.Lerp(0, maxAngleToRotate, time);
	}else{
		return angle = Mathf.Lerp(0, -maxAngleToRotate, -time);
	}
}


}
