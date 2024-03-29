﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformParenting : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("EnviromentCollider"))
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("EnviromentCollider"))
        {
            other.transform.parent = null;
        }
    }
}
