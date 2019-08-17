using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastAndSlow : MonoBehaviour
{
    public AudioSource playsound;
    public AudioClip splash;
    [SerializeField] private int fastAndSlowScale = 1;
    [SerializeField] private GameObject effect;
    [SerializeField] private GameObject soundPlayer;

    private void OnTriggerEnter(Collider other)
    {
        FastAndSlowEffect fastAndSlowEffect = other.gameObject.GetComponent<FastAndSlowEffect>();

        if (fastAndSlowEffect)
        {
            fastAndSlowEffect.NewTimeScale(fastAndSlowScale);
        }

        if (!other.CompareTag("Player") && !other.CompareTag("EnviromentCollider"))
        {
            Transform fx = Instantiate(effect).transform;
            fx.position = transform.position;
            Destroy(this.gameObject);
        }
    }
}
