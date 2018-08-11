using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TapToSetWorldOrigin : MonoBehaviour
{   
	public ARSessionOrigin arOrigin;
       
	public ARCameraRig cameraRig;
    
	private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

	new private Camera camera;


	private void Start()
	{
		camera = cameraRig.camera;
		if (camera == null)
		{
			Debug.LogError("ERROR: no camera");
		}
	}


	void Update()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			hitResults.Clear();
			arOrigin.Raycast(Input.GetTouch(0).position, hitResults);
			if (hitResults.Count > 0)
			{
				Pose hitPose = hitResults[0].pose;

				Pose worldPose = new Pose();
				worldPose.position = hitPose.position;

				Vector3 facingDirection = camera.transform.forward;
				facingDirection.y = 0;
				facingDirection.Normalize();
				worldPose.rotation = Quaternion.LookRotation(facingDirection, Vector3.up);

				cameraRig.SetWorldOrigin(worldPose);
			}         
		}
	}
}
