using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOuterEnemy : MonoBehaviour {

	public GameObject player;
	void Update()
	{
		if (player != null)
			transform.position = new Vector3(transform.position.x, player.transform.position.y - 3, transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
		if (enemyHealth != null)
		{
			enemyHealth.TakeDamage(10);
		}
	}
}
