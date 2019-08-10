using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Gun Pickup")
		{
			pa.pickedUpGun();
		}
	}

}
