using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Text gameScore;
	public Text FinalScore;
	public void GameOver()
	{
		
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
		GameObject.FindGameObjectWithTag("Play Again").GetComponentInChildren<Button>().enabled = true;
		GameObject.FindGameObjectWithTag("Play Again").GetComponentInChildren<Image>().enabled = true;
		GameObject.FindGameObjectWithTag("Play Again").GetComponentInChildren<Text>().enabled = true;
		GameObject.FindGameObjectWithTag("GAME OVER").GetComponentInChildren<Text>().enabled = true;
		GameObject.FindGameObjectWithTag("GAME OVER").GetComponentInChildren<Outline>().enabled = true;
		FinalScore.text = gameScore.text;
		GameObject.FindGameObjectWithTag("FinalScore").GetComponentInChildren<Text>().enabled = true;
		GameObject.FindGameObjectWithTag("FinalScore").GetComponentInChildren<Outline>().enabled = true;
		gameScore.gameObject.SetActive(false);

	}

	public void PlayAgain()
	{

		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
}