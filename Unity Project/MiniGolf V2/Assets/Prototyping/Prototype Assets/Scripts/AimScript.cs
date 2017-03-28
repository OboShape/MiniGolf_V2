using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AimScript : MonoBehaviour {

	// going to use raycasting to cast onto a plane to get direction to fire
	private AimArrowSprite m_arrowSprite;
	private Camera m_viewCam;

	[Range(1f, 5f)] public float aimPlaneScale;


	void Start()
	{
		m_arrowSprite = GetComponentInChildren<AimArrowSprite>();
		m_viewCam = Camera.main;
	}


	void Update()
	{
		// create ray
		Ray ray = m_viewCam.ScreenPointToRay(Input.mousePosition);
		// create the aim plane
		Plane groundPlane = new Plane (
			// just need to declare 3 corner points to create the plane, as it iterpolates the 4th corner.
			// doing it this way, creates the plane dead centre of the ball
			new Vector3(transform.position.x + 10f, transform.position.y, transform.position.z-10f),
			new Vector3(transform.position.x - 10f, transform.position.y, transform.position.z-10f),
			new Vector3(transform.position.x + 10f, transform.position.y, transform.position.z+10f));
		// used for raycasting out, logs hit distance
		float rayDistance;

		if(groundPlane.Raycast(ray, out rayDistance))
		{
			Vector3 point = ray.GetPoint(rayDistance);
			// since the plane is at same Y level as ball, set the aim arrow to look at the hit point. 
			// (always uses the transforms local forward vector, this way the arrow is always flat)
			transform.LookAt(point);
		}


	}

}

