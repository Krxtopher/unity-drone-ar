using UnityEngine;
using System.Collections;

public class WorldPositionTestTrigger : MonoBehaviour
{
	public TapToSetWorldOrigin cameraFocusController;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Focus from click");         
			Pose pose = new Pose(transform.position, transform.rotation);
         
			cameraFocusController.FocusOn(pose);
		}
	}
}
