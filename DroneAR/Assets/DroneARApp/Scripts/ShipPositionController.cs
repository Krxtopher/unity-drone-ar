using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPositionController : MonoBehaviour
{
	public ShipPositionGoal positionGoalModel;

	public Transform impactIndicator;


	void Update()
	{
		UpdatePositionGoal();
		impactIndicator.transform.position = positionGoalModel.position;
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

	//private void UpdatePositionGoal()
    //{
    //    Transform cameraTransform = Camera.main.transform;
    //    Transform cameraLocalTransform = cameraLocalTransform.
    //    LayerMask layerMask = 1 << 9;
    //    RaycastHit hit;
    //    if (Physics.Raycast(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
    //    {
    //        positionGoalModel.position = hit.point;
    //    }
    //}
}
