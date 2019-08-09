using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FastAndSlowEffect : MonoBehaviour
{
    public float timeScale = 1f;
    private float minTimeScale = 0;

    [Header("Fill in Applicable")]
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private MovingPlatform movingPlatform;
    [SerializeField] private speedingPlatform speedingPlatform;

    private Vector3 DefaultVelocity;

    private float DefaultNavMeshSpeed;

    private float DefaultWaitToGoBack;
    private float DefaultplatformSpeed;

    private float DefaultSpeedPlatform;

    private void Start()
    {
        if (rigidbody)
        {
            DefaultVelocity = rigidbody.velocity;
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
    }

    public void NewTimeScale(float pTimeChange)
    {
        timeScale = Mathf.Max(timeScale + pTimeChange, minTimeScale);

        if (rigidbody)
        {
            rigidbody.velocity = DefaultVelocity * timeScale;
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
            movingPlatform.waitToGoBack = DefaultWaitToGoBack * timeScale;
            movingPlatform.platformSpeed = DefaultplatformSpeed * timeScale;
        }
    }
}
