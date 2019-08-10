using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    [SerializeField] private Vector3 rotDir;
    public float rotSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotDir, rotSpeed, Space.Self);
    }
}
