using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

	public AudioSource audioClick;
	public AudioSource audioHover;

    public void PlayGame()
    {
		audioClick.Play();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
		audioClick.Play();
		Application.Quit();
    }

	public void HoverButton()
	{
		audioHover.Play();
	}
}
