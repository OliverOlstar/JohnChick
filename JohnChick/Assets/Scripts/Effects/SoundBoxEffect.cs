using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoxEffect : MonoBehaviour
{
    private int randomNumberEffect;
    private int randomTime;
    private AudioSource playsound;
    public AudioClip[] boxEffect;

    private float startTime;

    void Start()
    {
        playsound =  GetComponent<AudioSource>();
        startTime = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (startTime != Time.time)
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
