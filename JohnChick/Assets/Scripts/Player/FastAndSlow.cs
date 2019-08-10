using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastAndSlow : MonoBehaviour
{
   
    [SerializeField] private float fastAndSlowScale = 1;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        FastAndSlowEffect fastAndSlowEffect = other.gameObject.GetComponent<FastAndSlowEffect>();

        if (fastAndSlowEffect)
        {
            fastAndSlowEffect.NewTimeScale(fastAndSlowScale);
        }

        if (!other.CompareTag("Player") && !other.CompareTag("EnviromentCollider"))
        {
            Destroy(this.gameObject);
           
        }
    }
}
