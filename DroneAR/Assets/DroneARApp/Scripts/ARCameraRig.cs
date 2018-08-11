using UnityEngine;

public class ARCameraRig : MonoBehaviour
{
    
	new public Camera camera
	{
		get
		{
			return GetComponentInChildren<Camera>();
		}
	}
       
	public void SetWorldOrigin(Pose pose)
	{
		float yaw = Vector3.SignedAngle(Vector3.forward, pose.forward, Vector3.up);
		transform.RotateAround(pose.position, Vector3.up, -yaw);
		transform.position -= pose.position;
	}
}
