using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private Vector3 offsetPositon;
	[SerializeField] private Vector3 offsetRotation;


	private void Start()
	{
		target = GameObject.FindWithTag("Player").transform;
		offsetPositon = new Vector3(0f, 5f, -15f);
		offsetRotation = new Vector3(15f, 0, 0);
	}

	private void FixedUpdate()
	{
		if (target != null)
		{
			transform.position = target.position + offsetPositon;
			transform.rotation = target.rotation * Quaternion.Euler(offsetRotation);
		}
	}
}
