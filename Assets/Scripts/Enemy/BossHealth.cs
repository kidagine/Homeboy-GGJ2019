using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {

	public Slider bossSlider;
	public SpriteRenderer sprite;
	public GameObject won;
	public GameObject deathExplode;
	static public bool isBossDead = false;
	private int health = 40;

	void Start()
	{
		bossSlider.value = health;
	}

	public void TakeDamage(int damage)
	{
		sprite.color = Color.white;

		bossSlider.value -= 1;
		health -= damage;
		if (health <= 0)
		{
			won.SetActive(true);
			isBossDead = true;
			FindObjectOfType<AudioManager>().Play("Boss");
			Instantiate(deathExplode, transform.position, transform.rotation);
			Destroy(gameObject);
			PauseMenu.GameIsPaused = true;
		}
		Invoke("ResetColor", 0.2f);
	}

	void ResetColor()
	{
		sprite.color = Color.red;
	}


}
