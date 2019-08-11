using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMusic : MonoBehaviour
{
    [SerializeField] private List<AudioClip> clips;

    void Start()
    {
        GetComponent<AudioSource>().clip = clips[Random.Range(0, 2)];
    }
}
