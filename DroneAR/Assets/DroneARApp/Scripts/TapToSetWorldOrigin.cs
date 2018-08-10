using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TapToSetWorldOrigin : MonoBehaviour
{   
	public ARSessionOrigin arOrigin;

	public Transform cameraSpaceRotation;

	public Transform cameraOffset;

	public Transform arCamera;
       
	private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

	private Pose targetCameraPose;

	void Update()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			hitResults.Clear();
			arOrigin.Raycast(Input.GetTouch(0).position, hitResults);
			if (hitResults.Count > 0)
			{
				ARRaycastHit firstHitResult = hitResults[0];
				//FocusOn(firstHitResult.pose.position);
			}         
		}
        
		cameraOffset.transform.position = Vector3.Lerp(cameraOffset.transform.position, targetCameraPose.position, 0.05f);
		cameraSpaceRotation.transform.rotation = Quaternion.Slerp(cameraSpaceRotation.transform.rotation, targetCameraPose.rotation, 0.05f);
	}

	public void FocusOn(Pose pose)
	{
		targetCameraPose = new Pose();
		Pose localPose = cameraSpaceRotation.InverseTransformPose(pose);

		var targetPosRelativeToCamera = arCamera.InverseTransformPoint(pose.position);
		targetCameraPose.position = arCamera.position - targetPosRelativeToCamera;

		float yaw = Vector3.SignedAngle(cameraSpaceRotation.forward, pose.forward, Vector3.up);
		targetCameraPose.rotation = Quaternion.AngleAxis(-yaw, Vector3.up);

        //Vector3 cameraDirection = Camera.main.transform.forward;
        //Vector3 localCameraDirection = cameraSpace.InverseTransformVector(cameraDirection);
        //float cameraYaw = Vector3.SignedAngle(cameraDirection, Vector3.forward, Vector3.up);
        //Debug.Log("camera yaw: " + cameraYaw);

        //Quaternion counterRotate = Quaternion.AngleAxis(cameraYaw, Vector3.up);
        //cameraSpace.transform.rotation = counterRotate;
	}
}
