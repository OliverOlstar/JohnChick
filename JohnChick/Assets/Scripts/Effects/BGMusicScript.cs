using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicScript : MonoBehaviour
{
    private AudioSource sound;
    [SerializeField] private AudioClip musicLoop;

    private static BGMusicScript instance = null;
    public static BGMusicScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (sound.isPlaying == false)
        {
            sound.clip = musicLoop;
            sound.loop = true;
            sound.PlayDelayed(0.5f);
        }
    }
}
