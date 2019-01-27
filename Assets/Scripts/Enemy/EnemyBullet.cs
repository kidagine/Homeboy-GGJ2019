using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

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
		PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
		if (other.gameObject.CompareTag("Player"))
		{
			speed = 0;
			playerHealth.TakeDamage();
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
