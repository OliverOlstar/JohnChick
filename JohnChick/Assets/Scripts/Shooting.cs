using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Shooting : MonoBehaviour
{
    public AudioSource playSound;
    public AudioClip ShootingSound;

    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    public List<Transform> muzzle = new List<Transform>();
    [SerializeField] private float forwardForce;

    private int curMuzzle = 0;
    [SerializeField] private int bulletTimeScale = 1;

    public ParticleSystem muzzleFlash;

    [Header("Bullet")]
    [SerializeField] private float bulletsPerSec;
    [SerializeField] private float bulletLife;
    [SerializeField] private float bulletSize;

    public void StartShooting(GameObject pPrefab = null)
    {
        if (pPrefab != null)
            bulletPrefab = pPrefab;

        StartCoroutine("meShooting");
    }

    public void StopShooting()
    {
        StopCoroutine("meShooting");
    }

    IEnumerator meShooting()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            playSound.clip = ShootingSound;
            playSound.Play();
            bullet.transform.position = muzzle[curMuzzle].position;
            bullet.transform.forward = muzzle[curMuzzle].forward;
            bullet.transform.localScale *= bulletSize;

            if (!bullet.CompareTag("PlayerBullet"))
            {
                bulletTimeScale = GetComponent<FastAndSlowEffect>().timeScale;
                bullet.GetComponent<FastAndSlowEffect>().timeScale = bulletTimeScale;
            }

            bullet.GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x * forwardForce * bulletTimeScale, 0, transform.forward.z * forwardForce * bulletTimeScale), ForceMode.Impulse);
            
            playSound.clip = ShootingSound;
            playSound.Play();

            Destroy(bullet, bulletLife);

            CameraShaker.Instance.ShakeOnce(1, 2, 0.1f, 0.15f);
            if (muzzleFlash)
                muzzleFlash.Play();

            curMuzzle++;
            if (curMuzzle == muzzle.Count)
                curMuzzle = 0;

            yield return new WaitForSeconds( 1f / bulletsPerSec);
        }
    }
}
