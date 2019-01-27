using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovementHub : MonoBehaviour
{
	private bool canMove = true;
	private bool moving = false;
	private int speed = 10;
	private int movementCooldown = 0;
	private int currentTile = 0;
	private int currentTileVertical = 9;
	private DIRECTION dir = DIRECTION.LEFT;
	private Vector3 pos;

	private bool restRight;
	private bool restLeft;
	private bool restUp;
	void Update()
	{
		movementCooldown -= 1;
		if (canMove)
		{
			pos = transform.position;
			move();
		}

		if (moving)
		{
			if (transform.position == pos)
			{
				moving = false;
				canMove = true;

				move();
			}
			transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
		}
	}

	private void move()
	{
		if (movementCooldown <= 0)
		{
			if (Input.GetAxis("Horizontal") < 0 && currentTile >= -4)
			{
				if (dir != DIRECTION.LEFT)
				{
					movementCooldown = 4;
					dir = DIRECTION.LEFT;
				}
				else
				{
					currentTile--;
					canMove = false;
					moving = true;
					pos += Vector3.left;
				}
			}
			else if (Input.GetAxis("Horizontal") > 0 && currentTile <= 4)
			{
				if (dir != DIRECTION.RIGHT)
				{
					movementCooldown = 4;
					dir = DIRECTION.RIGHT;
				}
				else
				{
					currentTile++;
					canMove = false;
					moving = true;
					pos += Vector3.right;
				}
			}
			else if (Input.GetAxis("Vertical") < 0 && currentTileVertical <= 8)
			{
				if (dir != DIRECTION.UP)
				{
					movementCooldown = 4;
					dir = DIRECTION.UP;
				}
				else
				{
					currentTileVertical++;
					canMove = false;
					moving = true;
					pos += Vector3.up;
				}
			}
			else if (Input.GetAxis("Vertical") > 0)
			{
				if (dir != DIRECTION.DOWN)
				{
					movementCooldown = 4;
					dir = DIRECTION.DOWN;
				}
				else
				{
					currentTileVertical--;
					canMove = false;
					moving = true;
					pos += Vector3.down;
				}
			}
		}
	}

}
