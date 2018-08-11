using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPhysicsStart : MonoBehaviour {

	public Vector3 direction;

	public float intensity = 0.4f;

	// Use this for initialization
	void Start () {
		
		GetComponent<Rigidbody>().AddForce(direction.normalized * intensity, ForceMode.Impulse);
	}
	

}
