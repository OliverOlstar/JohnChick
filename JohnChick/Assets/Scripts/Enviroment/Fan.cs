using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float speed = 30f;
    [SerializeField] private List<float> windLength = new List<float>();

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 0.01f * speed / Vector3.Distance(other.transform.position, transform.position)); //add force in a direction
        else
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed / Vector3.Distance(other.transform.position, transform.position)); //add force in a direction
    }

    public void changeSize(int pSize)
    {
            transform.localScale = new Vector3(1, 1, windLength[pSize]);
    }
}
