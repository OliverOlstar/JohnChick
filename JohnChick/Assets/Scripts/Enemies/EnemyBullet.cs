using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerDeath>().KillPlayer(GetComponent<Rigidbody>().velocity.normalized);
        }
        
        Destroy(this.gameObject);
    }
}
