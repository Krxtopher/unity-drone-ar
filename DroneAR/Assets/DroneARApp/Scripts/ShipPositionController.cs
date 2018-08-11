using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPositionController : MonoBehaviour
{
	public ShipPositionGoal positionGoalModel;

	void Update()
	{
		UpdatePositionGoal();
	}


	private void UpdatePositionGoal()
	{
		Transform cameraTransform = Camera.main.transform;

		LayerMask layerMask = 1 << 9;
		RaycastHit hit;
		if (Physics.Raycast(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
		{
			positionGoalModel.position = hit.point;
		}
	}
}
