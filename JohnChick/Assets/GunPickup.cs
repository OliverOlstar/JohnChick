using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
	public GameObject muzzle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
    {
        
    }
}
