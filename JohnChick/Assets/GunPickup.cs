using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
	public PlayerAiming pa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Gun Pickup")
		{
			pa.pickedUpGun();
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
