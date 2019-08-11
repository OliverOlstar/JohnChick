﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSave : MonoBehaviour
{

	public float angle;
	public float force;
	Rigidbody rb;
	public GameManager gM;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
			rb.AddForce(dir * force);
			gM.score++;
			Destroy(gameObject, 3);
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody>();
		gM = FindObjectOfType<GameManager>().GetComponent<GameManager>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
