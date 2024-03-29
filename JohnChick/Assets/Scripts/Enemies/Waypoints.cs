﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
	[SerializeField]
	protected float debufDrawRadius = 1.0f;

	public virtual void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position,debufDrawRadius);
	}
}
