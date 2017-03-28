using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this script is just used to toggle the sprite renderer on and off
public class AimArrowSprite : MonoBehaviour {

	private SpriteRenderer m_AimArrowSprite;
	private bool m_aimArrowSpriteEnabled = true;

	void Awake()
	{
		m_AimArrowSprite = GetComponentInChildren<SpriteRenderer>();
	}

	public bool AimArrowIsVisible
	{
		set 
		{
			m_aimArrowSpriteEnabled = value;
			if(m_aimArrowSpriteEnabled)
				m_AimArrowSprite.enabled = true;
			else
				m_AimArrowSprite.enabled = false;
				
		}
		get { return m_aimArrowSpriteEnabled; } 
	}

	public void FaceTowards(Vector3 target)
	{
		transform.LookAt(target);
	}

}
