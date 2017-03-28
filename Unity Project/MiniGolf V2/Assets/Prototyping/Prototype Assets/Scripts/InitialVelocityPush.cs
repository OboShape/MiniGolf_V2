using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVelocityPush : MonoBehaviour {

	public Vector3 initialStrikeVelocity = Vector3.forward;

	private Rigidbody rb;


	void Start () {
		rb = GetComponent<Rigidbody>();	
		// add initial velocity to ball
		rb.AddForce(initialStrikeVelocity,ForceMode.VelocityChange);
	}

}
