using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ArrowOrganizer : MonoBehaviour
{

	private void Update()
	{
		OrganizeArrows();
	}

	private void OrganizeArrows()
	{
		int arrowCount = transform.childCount;
		int r = 2;
		float angle = Mathf.PI * 2f / arrowCount;

		for (int i = 0; i < arrowCount; i++)
		{
			Transform child = transform.GetChild(i);

			float nextAngle = i * angle;
			float horizontal = Mathf.Cos(nextAngle) * r;
			float vertical = Mathf.Sin(nextAngle) * r;

			Vector3 arrowPosition = transform.position +
				new Vector3(horizontal, vertical, 0f);

			if (i == 0)
				arrowPosition = transform.position;

			child.position = arrowPosition;
		}
	}
}