using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FastAndSlowEffect : MonoBehaviour
{
    [Range(0, 2)] public int timeScale = 1;
    private float minTimeScale = 0.1f;
    private float maxTimeScale = 2.0f;

    private float alreadyCalled = 0;

    [Header("Fill in Applicable")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private MovingPlatform movingPlatform;
    [SerializeField] private speedingPlatform speedingPlatform;
    [SerializeField] private Fan fan;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private Rotating rotations;
    [SerializeField] private AudioSource audioSource;

    [Header("Default Values")]
    private Vector3 DefaultVelocity;
    private float DefaultNavMeshSpeed;
    private float DefaultWaitToGoBack;
    private float DefaultplatformSpeed;
    private float DefaultSpeedPlatform;
    private float DefaultFanSpeed;
    private float DefaultAudioVolume;
    private float DefaultParticleSpeed;
    private float DefaultRotateSpeed;

    [Header("Material Changing")]
    [SerializeField] private Material slowMaterial;
    private Color slowColour = Color.cyan;
    [SerializeField] private Material fastMaterial;
    private Color fastColour = Color.red;
    [SerializeField] private Color[] defaultColours;

    [Space]
    [SerializeField] private float blinkSpeed = 0.6f;
    [SerializeField] private float blinkReturnSpeed = 1.1f;
    private float speed;

    private MeshRenderer[] renderers;
    private float timer = 0.0001f;
    private int direction = 1;
    private Color targetColour = Color.white;

    private void Start()
    {
        if (rb)
        {
            DefaultVelocity = rb.velocity;
        }

        if (navMeshAgent)
        {
            DefaultNavMeshSpeed = navMeshAgent.speed;
        }

        if (speedingPlatform)
        {
            DefaultSpeedPlatform = speedingPlatform.speed;
        }

        if (movingPlatform)
        {
            DefaultWaitToGoBack = movingPlatform.waitToGoBack;
            DefaultplatformSpeed = movingPlatform.platformSpeed;
        }

        if (fan)
        {
            DefaultFanSpeed = fan.speed;
        }

        if (particles)
        {
            DefaultParticleSpeed = particles.main.startSpeed.constant;
        }

        if (rotations)
        {
            DefaultRotateSpeed = rotations.rotSpeed;
        }

        if (audioSource)
        {
            DefaultAudioVolume = audioSource.volume;
        }

        //Colors
        if (fastMaterial != null)
            fastColour = fastMaterial.color;

        if (slowMaterial != null)
            slowColour = slowMaterial.color;

        renderers = GetComponentsInChildren<MeshRenderer>();
        defaultColours = new Color[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
            defaultColours[i] = renderers[i].material.color;
    }

    public void NewTimeScale(int pTimeChange)
    {
        //Protects from calling it twice on the same frame
        if (Time.time == alreadyCalled)
            return;
        else
            alreadyCalled = Time.time;

        

        timeScale = Mathf.Clamp(timeScale + pTimeChange, 0, 2);

        if (rb)
        {
            rb.velocity = DefaultVelocity * timeScale;
        }

        if (navMeshAgent)
        {
            navMeshAgent.speed = DefaultNavMeshSpeed * timeScale;
        }

        if (speedingPlatform)
        {
            speedingPlatform.speed = DefaultSpeedPlatform * timeScale;
        }

        if (movingPlatform)
        {
            movingPlatform.waitToGoBack = DefaultWaitToGoBack / (timeScale + 0.1f);
            movingPlatform.platformSpeed = DefaultplatformSpeed * (timeScale + 0.1f);
        }

        if (fan)
        {
            fan.speed = DefaultFanSpeed * (timeScale + 0.1f);
            fan.changeSize((int)timeScale);
        }

        if (particles)
        {
            particles.startSpeed = DefaultParticleSpeed * (timeScale + 0.1f);
        }

        if (rotations)
        {
            rotations.rotSpeed = DefaultRotateSpeed * (timeScale + 0.1f);
        }

        if (audioSource)
        {
            audioSource.volume = DefaultAudioVolume * (timeScale / 2f + 1f);
            DefaultAudioVolume = audioSource.volume;
        }

        //Blinking Color
        StopCoroutine("ChangeColour");
        Blink();
    }

    private void Blink()
    {
        switch (timeScale)
        {
            //Normal
            case 1:
                if (direction == 1)
                {
                    direction = -1;
                    timer = 1 - timer;
                }
                speed = blinkReturnSpeed;
                break;

            //Slow
            case 0:
                direction = 1;
                speed = blinkSpeed;
                targetColour = slowColour;
                break;
                
            //Fast
            case 2:
                direction = 1;
                speed = blinkSpeed;
                targetColour = fastColour;
                break;
        }

        //Start Colour Routine
        StartCoroutine("ChangeColour");
    }

    IEnumerator ChangeColour()
    {
        //Loop to change Colour
        while ((timer <= 1 && direction == 1) || (timer > 0 && direction == -1))
        {
            ChangeColor(timer, renderers, targetColour, defaultColours);

            timer += Time.deltaTime * speed * direction;
            yield return null;
        }

        //Restart Look going the other direction
        timer = direction == -1 ? 0.0001f : 1f;
        direction = direction * -1;

        if (timeScale != 1)
            StartCoroutine("ChangeColour");
    }

    private void ChangeColor(float t, MeshRenderer[] rendererss, Color targetColour, Color[] startingColours)
    {
        for (int i = 0; i < rendererss.Length; i++)
        {
            rendererss[i].material.color = (targetColour * t) + (startingColours[i] * (1 - t));
        }
    }
}
