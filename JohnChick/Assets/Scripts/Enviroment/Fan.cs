using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float speed = 30f;

    private void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed / Vector3.Distance(other.transform.position, transform.position)); //add force in a direction
    }
}
