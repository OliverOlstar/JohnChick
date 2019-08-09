using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float followHeight = 15f;
    [SerializeField] private float followDampening = 1f;
    [SerializeField] private float followOffset = 0f;

    void Start()
    {
        transform.position = new Vector3(_target.position.x, followHeight, _target.position.z - followOffset);
    }
    
    void Update()
    {
        Vector3 targetPos = new Vector3(_target.position.x, followHeight, _target.position.z - followOffset);

        transform.position = Vector3.Lerp(transform.position, targetPos, followDampening);
    }
}
