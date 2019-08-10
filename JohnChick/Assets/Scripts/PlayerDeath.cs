using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerDeath : MonoBehaviour
{
    private bool dead;

    [SerializeField] private PlayerCamera _camera;
    [SerializeField] private Transform _model;
    [SerializeField] private GameObject deadPrefab;
    [SerializeField] private float forceMult;

    public void Damage(Vector3 pForce)
    {
        if (dead) return;

        GameObject deadMe = Instantiate(deadPrefab);
        deadMe.transform.position = _model.position;
        deadMe.transform.rotation = _model.rotation;
        deadMe.GetComponent<Rigidbody>().AddForce(pForce * forceMult, ForceMode.Impulse);
        _camera._target = deadMe.transform;

        Time.timeScale = 0.15f;
        CameraShaker.Instance.StartShake(5, 2, 1);

        Destroy(this.gameObject);

        dead = true;
    }
}
