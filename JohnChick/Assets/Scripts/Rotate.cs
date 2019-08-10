using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotations;
    public float rotSpeed = 1f;

    void Update()
    {
        transform.Rotate(rotations, rotSpeed, Space.Self);
    }
}
