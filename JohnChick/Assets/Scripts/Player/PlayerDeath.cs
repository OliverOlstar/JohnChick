using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerDeath : MonoBehaviour
{
    private bool dead;
    private int randomNumberEffect;
    private AudioSource playsound;
    public AudioClip[] deathEffect;
    [SerializeField] private PlayerCamera _camera;
    [SerializeField] private Transform _model;
    [SerializeField] private GameObject deadPrefab;
    [SerializeField] private float forceMult;

    private void Start()
    {
        playsound = GetComponent<AudioSource>();
    }
    public void KillPlayer(Vector3 pForce)
    {
        if (dead) return;

        GameObject deadMe = Instantiate(deadPrefab);
        deadMe.transform.position = _model.position;
        deadMe.transform.rotation = _model.rotation;
        deadMe.GetComponent<Rigidbody>().AddForce(pForce * forceMult, ForceMode.Impulse);
        _camera._target = deadMe.transform;

        Time.timeScale = 0.15f;
        CameraShaker.Instance.StartShake(5, 2, 1);
        playEffect();
        Destroy(this.gameObject);

        dead = true;
    }

    private void playEffect()
    {
        randomNumberEffect = Random.Range(0, deathEffect.Length);
        playsound.clip = deathEffect[randomNumberEffect];
        playsound.volume = 0.35f;
        playsound.Play();
    }
}
