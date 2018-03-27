using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public Text scoreText;
	public Text gameOverScore;
	public Text topScore;
	private int score = 0;
	public GameObject panelGameOver;
	public bool gameOver;
	private bool isGameActive;

    private void Awake(){
		Instance = this;
	}

	public bool IsGameActive{
		get{
			return isGameActive;
		   }
	}

	public void StartGame(){
		isGameActive = true;
		ShowScore(true);
	}

	public void GameOver(){
		isGameActive = false;
		gameOver = true;
		ScoreToScoreUI(gameOverScore, score, "Score");
		ActivateGameOverPanel(true);
		ShowScore(false);
		SaveTopScore(score);
		ScoreToScoreUI(topScore, PlayerPrefs.GetInt("TopScore"), "Top Score");


	}

	public void AddScore(){
		score++;
		scoreText.text = score.ToString();
	}

	public void SaveTopScore(int score){
		if(PlayerPrefs.GetInt("TopScore") < score){
			PlayerPrefs.SetInt("TopScore", score);
		}
	}

	public void ShowScore(bool value){
		scoreText.gameObject.SetActive(value);
	}

	public void ActivateGameOverPanel(bool value){
		panelGameOver.gameObject.SetActive(value);
	}

	public void ScoreToScoreUI(Text scoreText, int score, string title){
		scoreText.text = title+" "+score.ToString();
	}

}
