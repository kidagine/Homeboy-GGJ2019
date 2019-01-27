using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTextTime : MonoBehaviour {

	public float time;

	void Start () {
		Destroy(gameObject, time);
	}
}
