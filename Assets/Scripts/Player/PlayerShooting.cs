using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
	public GameObject muzzlerPrefab;
	public GameObject reload;
	public SimpleCameraShakeInCinemachine cameraShake;
	public Slider gunClipSlider;
	private float cooldown = 0.3f;
	private int gunClip = 13;
	private bool isReloading;


	void Start()
	{
		gunClipSlider.value = gunClip;
	}

	void Update ()
	{
		if (!PauseMenu.GameIsPaused)
		{
			if (Input.GetMouseButton(0))
			{
				if (cooldown <= 0 && gunClip >= 1 && !isReloading)
				{
					Shoot();
					gunClipSlider.value -= 1f;
					cooldown = 0.3f;
					cameraShake.CameraShake();
				}
				else if (gunClip <= 0)
				{
					isReloading = true;
					reload.SetActive(true);
					FindObjectOfType<AudioManager>().Play("Reload");
					Invoke("Reload", 1);
				}
			}

			if (Input.GetKey(KeyCode.R) && gunClip != 13)
			{
				isReloading = true;
				reload.SetActive(true);
				FindObjectOfType<AudioManager>().Play("Reload");
				Invoke("Reload", 1);
			}

			PointingGun();
			reload.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
			cooldown -= Time.deltaTime;
		}
	}

	void Reload()
	{
		isReloading = false;
		reload.SetActive(false);
		gunClip = 13;
		gunClipSlider.value = gunClip;
	}

	void Shoot()
	{
		FindObjectOfType<AudioManager>().Play("Shot");
		Instantiate(muzzlerPrefab, firePoint.position, firePoint.rotation);
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		gunClip--;
	}

	void PointingGun()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);

		Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
		transform.up = direction;
	}
}
