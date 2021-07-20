using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public bool testMode;
	public int score;
	public int highscore;
	public int cratesLost;
	public int maxCratesLost;
	private bool isPaused;
	[Header("UI")]
	public GameObject mainMenu;
	public GameObject scoring;
	public GameObject deathScreen;
	public TextMeshProUGUI scoreDisplay;
	public TextMeshProUGUI highscoreDisplay;
	public TextMeshProUGUI cratesLostDisplay;
	public TextMeshProUGUI deathScore;
	public TextMeshProUGUI deathHighscore;
	public GameObject newHighscore;
	public GameObject paused;
	public GameObject tutorialScreen;

	private void Start()
	{
		if(!testMode)
			highscore = PlayerPrefs.GetInt("MainSave");
		highscoreDisplay.text = highscore.ToString();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			if (!isPaused)
				Pause();
		}
	}

	public void Resume()
	{
		paused.SetActive(false);
		Time.timeScale = 1f;
		GetComponent<Spawner>().isEnabled = true;
	}

	private void Pause()
	{
		paused.SetActive(true);
		Time.timeScale = 0f;
		GetComponent<Spawner>().isEnabled = false;
	}

	public void AddScore() 
	{
		score += 1;
		scoreDisplay.text = score.ToString();

		if (score > highscore) 
		{
			highscore = score;
			highscoreDisplay.text = highscore.ToString();
		}
	}

	public void LoseCrate() 
	{
		cratesLost++;
		cratesLostDisplay.text = $"{cratesLost} / {maxCratesLost}";

		if (cratesLost >= maxCratesLost) 
		{
			EndGame();
		}
	}

	public void EndGame() 
	{
		if(!testMode)
			PlayerPrefs.SetInt("MainSave", highscore);

		deathScreen.SetActive(true);
		deathScore.text = score.ToString();
		deathHighscore.text = highscore.ToString();

		if (highscore == score) 
		{
			newHighscore.SetActive(true);
		}

		GetComponent<Spawner>().isEnabled = false;
		GetComponent<Spawner>().enabled = false;
		GetComponent<Turner>().enabled = false;

		score = 0;
		scoreDisplay.text = "0";
		GetComponent<Spawner>().timeBetweenSpawns = 15;

		GameObject[] crates = GameObject.FindGameObjectsWithTag("Player");
		foreach (var o in crates) 
		{
			Destroy(o);
		}

		StartCoroutine(GoToMainMenu());
	}

	public IEnumerator GoToMainMenu() 
	{
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		deathScreen.SetActive(false);
		newHighscore.SetActive(false);
		scoring.SetActive(false);
		mainMenu.SetActive(true);
	}

	public void Play() 
	{
		GetComponent<Spawner>().enabled = true;
		GetComponent<Spawner>().isEnabled = true;
		GetComponent<Turner>().enabled = true;
		mainMenu.SetActive(false);
		scoring.SetActive(true);
		highscore = PlayerPrefs.GetInt("MainSave");
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void HowToPlay() 
	{
		tutorialScreen.SetActive(true);
	}

	public void CloseHowTo() 
	{
		tutorialScreen.SetActive(false);
	}
}
