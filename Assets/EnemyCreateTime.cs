using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreateTime : MonoBehaviour {

	public float time;

	void Start () {
		Invoke("CreateEnemy", time);
	}

	void CreateEnemy()
	{
		transform.GetChild(0).gameObject.SetActive(true);
	}
}
