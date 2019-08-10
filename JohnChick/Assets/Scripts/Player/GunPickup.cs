using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponentInChildren<PlayerAiming>().pickedUpGun();
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.left, 1);
    }
}
