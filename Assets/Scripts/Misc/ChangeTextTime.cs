using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextTime : MonoBehaviour {

	public Text message;

	void Start () {
		PauseMenu.GameIsPaused = true;
		Invoke("ChangeTextFirst", 6);
	}

	void ChangeTextFirst()	
	{
		message.text = "OF ALL BOXES, NONE WERE MORE PATHETIC,\nTHAN HOMEBOY.";
		Invoke("ChangeTextSecond", 5.5f);
	}

	void ChangeTextSecond()
	{
		message.text = "BUT THE STREET GANGS\nWERE NOW APPROACHING HIS HOME. ";
		Invoke("ChangeTextThird", 4.5f);
	}

	void ChangeTextThird()
	{
		message.text = "NOW HOMEBOY HAS TO PICK HIS GUN\nAND PROTECT WHAT FEELS LIKE HOME!";
		Destroy(gameObject, 5F);
		PauseMenu.GameIsPaused = false;
	}
}
