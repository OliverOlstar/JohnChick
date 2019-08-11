using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSave : MonoBehaviour
{

	public float angle;
	public float force;
    public ScoreCont SC;
	Rigidbody rb;
    public int me = 0;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
			rb.AddForce(dir * force);
            SC._score.Add(me);
			Destroy(gameObject, 3);
		}
	}
    
	void Start()
    {
		rb = GetComponent<Rigidbody>();
        SC = FindObjectOfType<ScoreCont>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
