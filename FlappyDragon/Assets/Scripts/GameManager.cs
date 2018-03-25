using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public Text scoreText;
	public Text gameOverScore;
	private int score = 0;
	public GameObject panelGameOver;
	public bool gameOver;

    private void Awake(){
		Instance = this;
	}

	public bool IsGameActive{
		get{return isGameActive;}

	}

	private bool isGameActive;

	public void StartGame(){
		isGameActive = true;
		scoreText.gameObject.SetActive(true);
	}

	public void GameOver(){
		isGameActive = false;
		gameOver = true;
		panelGameOver.gameObject.SetActive(true);
		gameOverScore.text = score.ToString();
		scoreText.gameObject.SetActive(false);

	}

	public void AddScore(){
		score++;
		scoreText.text = score.ToString();
	}
}
