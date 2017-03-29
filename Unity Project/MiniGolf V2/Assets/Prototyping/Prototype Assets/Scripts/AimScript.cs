using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AimScript : MonoBehaviour {

	// going to use raycasting to cast onto a plane to get direction to fire
	private AimArrowSprite m_arrowSprite;
	private Camera m_viewCam;

	void Start()
	{
		m_arrowSprite = GetComponentInChildren<AimArrowSprite>();
		m_viewCam = Camera.main;

		Plane newPlane = new Plane(
	}


	void Update()
	{
		// create ray
		Ray ray = m_viewCam.ScreenPointToRay(Input.mousePosition);
		// create the aim plane
		Plane groundPlane = new Plane(Vector3.up, transform.position);

		// used for raycasting out, logs hit distance
		float rayDistance;

		if(groundPlane.Raycast(ray, out rayDistance))
		{
			Vector3 point = ray.GetPoint(rayDistance);
			// so i can see the ray
			Debug.DrawLine(ray.origin, point,Color.red);
			// since the plane is at same Y level as ball, set the aim arrow to look at the hit point. 
			// (always uses the transforms local forward vector, this way the arrow is always flat)
			transform.LookAt(point);
		}


	}

	void OnDrawGizmos()
	{
		Gizmos.DrawLine(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z-1f),
								new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z-1f)); 
	}
}

