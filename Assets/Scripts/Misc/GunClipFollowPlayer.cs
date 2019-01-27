using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunClipFollowPlayer : MonoBehaviour {

	public GameObject player;
	public RectTransform rectTransform;
	void Start()
	{
	}
	void Update () {
		rectTransform.localPosition = player.transform.position;
	}
}
