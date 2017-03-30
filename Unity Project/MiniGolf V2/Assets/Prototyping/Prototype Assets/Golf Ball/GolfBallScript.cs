using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallScript : MonoBehaviour {

	private Rigidbody m_ballRigidbody;
	private AimScript m_AimScript;


	void Start()
	{
		// find golf ball RigidBody and store reference
		m_ballRigidbody = GetComponent<Rigidbody>();
		if (m_ballRigidbody == null) {Debug.LogWarning ("Ball Rigidbody Not Found");}	else {Debug.Log ("Ball Rigidbody Script Found");	}
		// find Aim Script and store reference
		m_AimScript = GetComponentInChildren<AimScript>();
		if (m_AimScript == null) {Debug.LogWarning ("Aim Script Not Found");}	else {Debug.Log ("Aim Script Script Found");	}

	}

	public void StrikeBall(float forceMultiplier)
	{
		m_ballRigidbody.AddForce(m_AimScript.GetAimDirectionUnitVector() * forceMultiplier);
	}

	public void AimingEnabled(bool isAimingEnabled)
	{
		m_AimScript.AimingEnabled = isAimingEnabled;
	}
}
