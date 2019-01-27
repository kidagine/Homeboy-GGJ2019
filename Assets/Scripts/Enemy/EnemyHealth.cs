using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public SpriteRenderer sprite;
	private int health = 2;

	public void TakeDamage(int damage)
	{
		sprite.color = Color.white;

		health -= damage;
		if (health <= 0)
		{
			Destroy(gameObject);
		}
		Invoke("ResetColor", 0.2f);
	}

	void ResetColor()
	{
		sprite.color = Color.red;
	}

}
