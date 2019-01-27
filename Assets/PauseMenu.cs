using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;

	void Start()
	{
		FindObjectOfType<AudioManager>().Play("Hub");
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
			{
			Resume();
			}
			else
			{
			Pause();
			}
		}

		if (PlayerHealth.isDead == true)
		{
			Invoke("Retry", 3f);
		}
		if (BossHealth.isBossDead == true)
		{
			Invoke("End", 8f);
		}
	}
	private void End()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void Resume()
	{
		FindObjectOfType<AudioManager>().Play("Click");
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1;
		GameIsPaused = false;
	}

	public void Pause()
	{
		FindObjectOfType<AudioManager>().Play("Click");
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0;
		GameIsPaused = true;
	}

	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1;
		GameIsPaused = false;
		PlayerHealth.isDead = false;
	}

	public void QuitGame()
	{
		FindObjectOfType<AudioManager>().Play("Click");
		Application.Quit();
	}

	public void Hover()
	{
		FindObjectOfType<AudioManager>().Play("Hover");
	}
}
