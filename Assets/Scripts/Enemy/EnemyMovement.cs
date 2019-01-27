using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed;
	private float cooldown = 0.4f;
	
	void Update()
	{
	
			transform.Translate(Vector2.down * speed * Time.deltaTime);
			cooldown = 0.4f;

	}

}
