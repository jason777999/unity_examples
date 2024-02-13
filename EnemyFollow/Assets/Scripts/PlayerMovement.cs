/*
PlayerMovement.cs
Script for movng a players rigid body around.
*/

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 10.0f;
	public float turnSpeed = 10f;
	public bool isPosRandom = true;

	private Rigidbody playerRigidbody;
	private float movmentMag;
	private float rotateMag;

	void Awake()
	{
		this.playerRigidbody = this.GetComponent<Rigidbody>();
		if(this.isPosRandom)
		{
			float margin = 10.0f;
			Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(
				Random.Range(margin, Screen.width - margin),
				Random.Range(margin, Screen.height - margin),
				Camera.main.transform.position.y));
			screenPosition.y = 0;
			this.transform.position = screenPosition;
		}
	}

	void Update()
	{
		this.movmentMag = 0;
		this.rotateMag = 0;

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow))
		{
			movmentMag += 1;
		}
		if (Input.GetKey (KeyCode.S)  || Input.GetKey (KeyCode.DownArrow))
		{
			movmentMag -= 1;
		}

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow))
		{
			rotateMag -= 1;
		}
		if (Input.GetKey (KeyCode.D)  || Input.GetKey (KeyCode.RightArrow))
		{
			rotateMag += 1;
		}
	}

	void FixedUpdate ()
	{
		Vector3 movement = this.transform.forward * this.movmentMag *
			this.speed * Time.deltaTime;

		this.playerRigidbody.MovePosition(
			this.playerRigidbody.position + movement);

		Quaternion turnRotation = Quaternion.Euler(
			0f, this.rotateMag * this.turnSpeed * Time.deltaTime, 0f);

		this.playerRigidbody.MoveRotation(this.playerRigidbody.rotation *
			turnRotation);
	}
}
