﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for the speeding platforms 
public class speedingPlatform : MonoBehaviour
{
    public float speed = 30f;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("PlayerBullet"))
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.right * speed); //add force in a direction
    }
}
