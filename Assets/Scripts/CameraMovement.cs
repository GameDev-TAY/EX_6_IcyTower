using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{

	public GameManager gameManager;

	private float speed;
	public float speedMultiple = 2f;

	private Vector3 targetPosition;
	public Transform target;

	private float distance;

	public float startLimmit = 7f;
	public float maxDistanceBeforeLose = 7f;
	private float timer;



	void Start()
	{
		timer = 0;
	}
	void LateUpdate()
	{
		distance = target.position.y - transform.position.y;

		if (target.position.y < startLimmit)
			return;

		if (distance < -maxDistanceBeforeLose) //Outside the camera boundaries
		{
			gameManager.GameOver();
		}

		else if (distance > 1) //Gradual change
		{
			targetPosition = new Vector3(0, target.position.y, transform.position.z);
			transform.position = Vector3.Lerp(transform.position, targetPosition, distance * Time.deltaTime);
		}

		else //Regular move
		{
			targetPosition = new Vector3(0, transform.position.y + speed, transform.position.z);
			transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
			
	
		}

		timer += Time.deltaTime;
		speed = (1 + (timer) / 60) * speedMultiple;

	}


}