using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponentInChildren<PlayerAiming>().pickedUpGun();
            Destroy(this.gameObject);
        }
    }

<<<<<<< HEAD:JohnChick/Assets/GunPickup.cs
	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Gun Pickup")
		{
			col.gameObject.transform.parent = muzzle.transform;
			col.transform.position.Set(muzzle.transform.position.x, muzzle.transform.position.y, muzzle.transform.position.z);
		}
	}

	// Update is called once per frame
	void Update()
=======
    private void Update()
>>>>>>> parent of 18a3ded... fixed player prefab, level1 and gunscript:JohnChick/Assets/Scripts/Player/GunPickup.cs
    {
        transform.Rotate(Vector3.left, 1);
    }
}
