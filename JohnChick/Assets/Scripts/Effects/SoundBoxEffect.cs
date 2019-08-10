using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoxEffect : MonoBehaviour
{
    private int randomNumberEffect;
    private int randomTime;
    public AudioSource playsound;
    public AudioClip[] boxEffect;

    void Start()
    {
        playsound =  GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        playEffect();
    }

    private void playEffect()
    {
        randomNumberEffect = Random.Range(0, boxEffect.Length);       
        playsound.clip = boxEffect[randomNumberEffect];
        playsound.volume = 0.35f;
        playsound.Play();
    }
}
