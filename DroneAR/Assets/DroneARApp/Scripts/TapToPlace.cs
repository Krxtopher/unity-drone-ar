using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TapToPlace : MonoBehaviour
{   
	public ARSessionOrigin arSpace;

	public GameObject targetObject;


	private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();


	void Update()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			hitResults.Clear();
			arSpace.Raycast(Input.GetTouch(0).position, hitResults);
			if (hitResults.Count > 0)
			{
				ARRaycastHit firstHitResult = hitResults[0];
				Vector3 facingDirection = Camera.main.transform.forward;
				facingDirection.y = 0;

				PositionTargetObject(firstHitResult.pose.position, facingDirection);
			}         
		}
	}


	private void PositionTargetObject(Vector3 position, Vector3 direction)
	{
		targetObject.transform.position = position;

		Quaternion rotation = Quaternion.LookRotation(direction);
		targetObject.transform.rotation = rotation;
	}
}
