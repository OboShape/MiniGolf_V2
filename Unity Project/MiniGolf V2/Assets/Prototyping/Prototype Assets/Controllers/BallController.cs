using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float forceMultiplier = 5f;
	private GolfBallScript m_golfBall;

	void Start () {
		PopulateInitialReferences ();
		m_golfBall.AimingEnabled(true);
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			m_golfBall.StrikeBall(forceMultiplier);
			m_golfBall.AimingEnabled(false);
		}
	}

	void PopulateInitialReferences ()
	{
		// find the golf ball in the scene and save reference
		m_golfBall = GameObject.FindGameObjectWithTag ("GolfBall").GetComponent<GolfBallScript>();
		if (m_golfBall == null) {Debug.LogWarning ("Ball Not Found");}	else {Debug.Log ("Ball Found");}
	}
}
