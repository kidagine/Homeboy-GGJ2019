using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeNextScene : MonoBehaviour {

	public Animator fadeInAnim;
	public GameObject player;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Destroy(player);
			Debug.Log("OKAY");
			fadeInAnim.SetTrigger("FadeIn");
			Invoke("GoToNextScene", 1.2f);
		}
	}

	void GoToNextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
