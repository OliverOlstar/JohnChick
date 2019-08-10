using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
	public PlayerAiming pa;
	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Gun Pickup")
		{
			pa.pickedUpGun();
		}
	}

}
