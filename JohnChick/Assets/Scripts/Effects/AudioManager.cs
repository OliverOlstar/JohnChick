using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] list;
    private AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        Bxtople();
    }

    public void soundArray()
    {
        //Loading the items into the array
        list = new AudioClip[]
        {                            (AudioClip)Resources.Load("Assets/SFX/Box1"),
                                     (AudioClip)Resources.Load("Assets/SFX/Box2"),
                                     (AudioClip)Resources.Load("Assets/SFX/Box3"),
                                     (AudioClip)Resources.Load("Assets/SFX/Box4"),
                                     (AudioClip)Resources.Load("Assets/SFX/Box5"),
                                     (AudioClip)Resources.Load("Assets/SFX/Box6")};
    }

    public void Bxtople()
    {
        AS.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
