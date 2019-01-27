using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour {

	public GameObject player;
	void Update ()
	{
		if (player != null)
		transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
	}
}
