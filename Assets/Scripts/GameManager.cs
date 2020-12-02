using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public Text gameScore;
	public Text menuScore;
	public Button GameOverText;
	public void GameOver()
	{
		/**
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
		GameOverText.GetComponent<Text>().enabled = true;
		GameOverText.GetComponent<Image>().enabled = true;
		menuScore.GetComponent<Text>().enabled = true;
		gameScore.GetComponent<Text>().enabled = true;
		**/
	}

	public void PlayAgain()
	{
		/**
		GameOverText.GetComponent<Text>().enabled = false;
		GameOverText.GetComponent<Image>().enabled = false;
		menuScore.GetComponent<Text>().enabled = false;
		gameScore.GetComponent<Text>().enabled = false;
		**/
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
}
