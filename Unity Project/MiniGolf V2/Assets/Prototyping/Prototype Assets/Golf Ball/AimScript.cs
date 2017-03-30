using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour {

	private SpriteRenderer m_arrowSprite;
	private bool m_ArrowSpriteVisible;
	private Camera m_viewCam;

	private bool m_AimingEnabled = false;

	void Awake()
	{
		m_arrowSprite = GetComponentInChildren<SpriteRenderer>();
		if (m_arrowSprite == null) {Debug.LogWarning ("Aim Sprite Not Found");}	else {Debug.Log ("Aim Sprite Script Found");	}
		m_viewCam = Camera.main;
	}


	void Update()
	{
		if(m_AimingEnabled)
			ShowAim();
	}


	//----------------------------------------------------
	//  PROPERTIES AND CLASS METHODS
	//----------------------------------------------------


	public Vector3 GetAimDirectionUnitVector()
	{
		return transform.forward;
	}

	public bool AimingEnabled
	{
		set 
		{
			if (value)
			{
				m_AimingEnabled = true;
				m_arrowSprite.enabled = true;
			}
			else
			{
				m_AimingEnabled = false;
				m_arrowSprite.enabled = false;
			}
		}
	}

	private void ShowAim()
	{
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

}

