using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHoverAnimation : MonoBehaviour
{   
	public float yMovementPeriod = 0.8f;

	public float yMagnitude = 0.025f;


	private Vector3 homeLocalPosition;


	private void Start()
	{
		homeLocalPosition = transform.localPosition;
	}

	void Update()
	{
		float yOffsetMagnitude = Mathf.Sin(Time.time / yMovementPeriod * Mathf.PI);
		transform.localPosition = homeLocalPosition + new Vector3(0, yOffsetMagnitude * yMagnitude, 0);
	}
}
