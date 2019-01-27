using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVertical : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed;

	void Start()
	{
		rb.velocity = transform.up * speed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Pause"))
		{
			rb.velocity = transform.up * 0;
			Invoke("Start", 30);
		}
	}
}
