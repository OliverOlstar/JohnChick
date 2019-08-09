using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FastAndSlowEffect : MonoBehaviour
{
    public float timeScale = 1f;

    [Header("Fill in Applicable")]
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private MovingPlatform movingPlatform;
    [SerializeField] private speedingPlatform speedingPlatform;

    private Vector3 DefaultVelocity;
    //private NavMeshAgent navMeshAgent;
    //private MovingPlatform movingPlatform;
    //private speedingPlatform speedingPlatform;

    private void Start()
    {
        //if (rigidbody)
        //{
        //    DefaultVelocity = rigidbody.velocity;
        //}

        //if (navMeshAgent)
        //{

        //}

        //if (speedingPlatform)
        //{

        //}

        //if (movingPlatform)
        //{

        //}
    }

    public void NewTimeScale(float pTimeChange)
    {
        timeScale = Mathf.Max(timeScale + pTimeChange, 0);

        //if (rigidbody)
        //{
        //    rigidbody.velocity = DefaultVelocity * 
        //}

        //if (navMeshAgent)
        //{

        //}

        //if (speedingPlatform)
        //{

        //}

        //if (movingPlatform)
        //{

        //}
    }
}
