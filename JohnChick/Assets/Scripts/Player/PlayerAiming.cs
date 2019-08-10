using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    private Shooting _shooting;
    [SerializeField] private GameObject slowBullet;
    [SerializeField] private GameObject fastBullet;
    [SerializeField] private ParticleSystem slowMuzzleFlash;
    [SerializeField] private ParticleSystem fastMuzzleFlash;
    [SerializeField] private Transform slowMuzzle;
    [SerializeField] private Transform fastMuzzle;

    [Header("TURN THIS ON IF YOU SHOULD HAVE GUN AT START OF LEVEL")]
    [SerializeField] private bool HasGun = false;
    [SerializeField] public GameObject myGun;

    private bool Gamepad = false;


    void Start()
    {
        _shooting = GetComponent<Shooting>();

        if (!HasGun)
            myGun.SetActive(false);
    }
    
    public void pickedUpGun()
    {
        myGun.SetActive(true);
        HasGun = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
            Gamepad = true;
        else if (Input.GetKeyDown(KeyCode.Space))
            Gamepad = false;
            
        if (Gamepad)
            RotationGamepad();
        else
            Rotation();

        if (HasGun)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _shooting.muzzleFlash = fastMuzzleFlash;
                _shooting.muzzle[0] = fastMuzzle;
                _shooting.StopShooting();
                _shooting.StartShooting(fastBullet);
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                _shooting.muzzleFlash = slowMuzzleFlash;
                _shooting.muzzle[0] = slowMuzzle;
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

    void RotationGamepad()
    {
        Vector3 joyInput = new Vector3(Input.GetAxis("HorizontalR"), 0, Input.GetAxis("VerticalR"));
        joyInput.Normalize();
        joyInput.y = transform.position.y;
        transform.forward = joyInput;
    }
}
