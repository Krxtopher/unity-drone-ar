using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

	public ShipPositionGoal positionGoalModel;

	public Transform shipBody;

	public float maxBankAngle = 45f;

	public float maxBankDistance = 0.5f;

	public float damping = 0.4f;

	void Update()
	{
		

		Vector3 localPosition = transform.localPosition;
		Vector3 goalLocalPosition = transform.parent.InverseTransformVector(positionGoalModel.position);
		goalLocalPosition.z = localPosition.z;

		float distanceFromGoalX = localPosition.x - goalLocalPosition.x;

        // Intensity of bank from -1 to 1.
		float bankIntensity = Mathf.Min(1f, Mathf.Max(-1f, distanceFromGoalX / maxBankDistance));
		float bankAngle = maxBankAngle * bankIntensity;
        
		Quaternion bankPose = Quaternion.AngleAxis(bankAngle, transform.InverseTransformDirection(transform.forward));
		transform.localRotation = bankPose;
        
		float dampingFactor = Time.deltaTime / damping;
		
		transform.localPosition = Vector3.Lerp(transform.localPosition, goalLocalPosition, dampingFactor);      
	}
}
