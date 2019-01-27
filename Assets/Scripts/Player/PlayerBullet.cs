using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	public float speed = 20f;
	public Rigidbody2D rb;
	public GameObject shotExplode;

	void Start()
	{
		rb.velocity = transform.up * speed;
		Invoke("Destroy", 1.2f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		BossHealth bossHealth = other.GetComponent<BossHealth>();
		EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
		if (enemyHealth != null)
		{
			speed = 0;
			enemyHealth.TakeDamage(1);
			Instantiate(shotExplode, transform.position, transform.rotation);
			Destroy(gameObject);
		}
		if (bossHealth != null)
		{
			speed = 0;
			bossHealth.TakeDamage(1);
			Instantiate(shotExplode, transform.position, transform.rotation);
			Destroy(gameObject);
		}
		else if (other.gameObject.CompareTag("Middle"))
		{
			speed = 0;
			Instantiate(shotExplode, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	
	}

	void Destroy()
	{
		Destroy(gameObject);
	}

}
