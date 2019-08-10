using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoxEffect : MonoBehaviour
{
    private int randomNumberEffect;
    private int randomTime;
    public AudioSource playsound;
    public AudioClip[] boxEffect;
    public float velocitaCollisione;
    void Start()
    {
        playsound =  GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude > velocitaCollisione)
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
