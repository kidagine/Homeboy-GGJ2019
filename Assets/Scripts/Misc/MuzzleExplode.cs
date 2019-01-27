using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleExplode : MonoBehaviour {

	public GameObject firePoint;

	void Start()
	{
		firePoint = GameObject.Find("FirePoint");
		Destroy(gameObject, 0.3f);
	}

	void Update()
	{
		if (firePoint != null)
		transform.position = firePoint.transform.position;
	}
}
