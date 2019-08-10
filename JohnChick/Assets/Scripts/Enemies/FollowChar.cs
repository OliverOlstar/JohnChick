using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChar : MonoBehaviour
{
	public float moveSpeed;
	public float rotationSpeed;
	public GameObject basePoint;
	// Start is called before the first frame update
	void Start()
    {
        
    }
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			transform.rotation = Quaternion.Slerp(transform.rotation,
			Quaternion.LookRotation(other.transform.position - transform.position), rotationSpeed * Time.deltaTime);
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}
		else
		{
			transform.rotation = Quaternion.Slerp(transform.rotation,
			Quaternion.LookRotation(basePoint.transform.position - transform.position), rotationSpeed * Time.deltaTime);
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}
	}

	
	// Update is called once per frame
	void Update()
    {
        
    }
}
