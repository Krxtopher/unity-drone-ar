using UnityEngine;
using System.Collections;

public class WorldPositionTestTrigger : MonoBehaviour
{
	public ARCameraRig cameraRig;

	public Transform hitShapeTransform;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			var position = Input.mousePosition;
			ScreenHit(position);         
		}
		else if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
			var position = Input.GetTouch(0).position;
			ScreenHit(position);
        }
	}

	private void ScreenHit(Vector3 screenPosition)
	{
		Ray ray = cameraRig.camera.ScreenPointToRay(screenPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == hitShapeTransform)
            {
                Pose hitPose = new Pose(transform.position, transform.rotation);

				Pose worldPose = new Pose();
				worldPose.position = hitPose.position;

				Vector3 facingDirection = cameraRig.camera.transform.forward;
				facingDirection.y = 0;
				facingDirection.Normalize();
				worldPose.rotation = Quaternion.LookRotation(facingDirection, Vector3.up);

				cameraRig.SetWorldOrigin(worldPose);
            }
        }
	}
}
