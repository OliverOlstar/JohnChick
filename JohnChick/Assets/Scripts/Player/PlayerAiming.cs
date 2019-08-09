using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    private Shooting _shooting;
    [SerializeField] private GameObject slowBullet;
    [SerializeField] private GameObject fastBullet;


    void Start()
    {
        _shooting = GetComponent<Shooting>();
    }
    
    void Update()
    {
        Rotation();

        if (Input.GetButtonDown("Fire1"))
        {
            _shooting.StopShooting();
            _shooting.StartShooting(fastBullet);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            _shooting.StopShooting();
            _shooting.StartShooting(slowBullet);
        }

        if (!Input.GetButton("Fire1") && !Input.GetButton("Fire2"))
        {
            if (Input.GetButtonUp("Fire1") || Input.GetButtonUp("Fire2"))
            {
                _shooting.StopShooting();
            }
        }
    }

    void Rotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - transform.position;
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
    }
}
