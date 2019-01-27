using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour {

	public GameObject bullet;
	public GameObject bulletHoming;
	public GameObject target;
	public Transform firePoint;
	public Transform firePointTwo;
	private float cooldown = 6f;
	private float cooldownDouble = 4f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null)
		{
			transform.up = target.transform.position - transform.position;
		}

		if (cooldownDouble <= 0)
		{
			Debug.Log("SHOT");
			ShootDouble();
			cooldownDouble = 4f;
		}
		cooldownDouble -= Time.deltaTime;
	}


	void ShootDouble()
	{
		if (firePoint != null && firePointTwo != null)
		{
			Instantiate(bullet, firePoint.position, firePoint.rotation);
			Instantiate(bullet, firePointTwo.position, firePointTwo.rotation);
		}
	}
}
