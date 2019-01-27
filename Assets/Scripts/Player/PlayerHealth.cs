using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int health;
	public int heartNumber;
	public Image[] hearts;
	public Sprite fullHeart;
	public GameObject retryMenuUI;
	public GameObject playerDeath;
	public Animator anim;
	static public bool isDead = false;
	private float cooldown = 0.3f;


	void Update () {
		for (int i = 0; i < hearts.Length; i++)
		{
		

			if (i <= heartNumber)
			{
				hearts[i].enabled = true;
			}
			if (i >= heartNumber)
			{
				hearts[i].enabled = false;
			}
		}

		if (health <= 0 && !isDead && !BossHealth.isBossDead)
		{
			Destroy(gameObject);
			FindObjectOfType<AudioManager>().Play("Death");
			Instantiate(playerDeath, new Vector2(transform.position.x,transform.position.y + 1), Quaternion.identity);
			isDead = true;
			retryMenuUI.SetActive(true);
		}
		cooldown -= Time.deltaTime;
	}

	public void TakeDamage()
	{
		if (cooldown <= 0)
		{
			anim.SetTrigger("Hit");
			health--;
			heartNumber--;
			cooldown = 1.2f;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemy") && cooldown <= 0)
		{
			anim.SetTrigger("Hit");
			health--;
			heartNumber--;
			cooldown = 1.2f;
		}
	}
}
