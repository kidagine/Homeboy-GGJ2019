using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoming : MonoBehaviour {

	public GameObject bulletPrefab;
	private float cooldown = 0.8f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (cooldown <= 0)
		{
			Shoot();
			cooldown = 1.2f;
		}
		cooldown -= Time.deltaTime;
	}

	void Shoot()
	{
			FindObjectOfType<AudioManager>().Play("Shot");
			Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
	}
}
