using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splattt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	private void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "Ground")
		{
			transform.localScale.Set(1.2f,0.2f,1.2f);
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
