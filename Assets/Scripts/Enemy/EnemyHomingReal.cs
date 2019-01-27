using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomingReal : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject target;
	public Transform firePoint;
	private float cooldown = 1.7f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null)
		{
			transform.up = target.transform.position - transform.position;
		}

		if (cooldown <= 0)
		{
			Shoot();
			cooldown = 1.2f;
		}
		cooldown -= Time.deltaTime;
	}

	void Shoot()
	{
		if (firePoint != null)
		{
			FindObjectOfType<AudioManager>().Play("Shot");
			Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		}
	}
}
