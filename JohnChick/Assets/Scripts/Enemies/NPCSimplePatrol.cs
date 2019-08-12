using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSimplePatrol : MonoBehaviour
{

	[SerializeField]
	bool _patrolWaiting;

	[SerializeField]
	float _totalWaitTime = 3f;

	[SerializeField]
	float _switchProbability = 0.2f;
    
    [HideInInspector]
    public Waypoints[] _patrolPoints;

	NavMeshAgent _navMeshAgent;
	int _currentPatrolIndex;
	bool _travelling;
	bool _waiting;
	bool _patrolForward;
	float _waitTimer;
    
    void Start()
    {
		_navMeshAgent = this.GetComponent<NavMeshAgent>();

		if (_navMeshAgent==null)
            return;
		else
		{
			if (_patrolPoints.Length >= 2)
			{
				_currentPatrolIndex = 0;
				SetDestination();
			}
            else
            {
                _navMeshAgent.speed = 0;
            }
		}
    }
    
    void Update()
    {
        if (_patrolPoints.Length < 2)
            return;

        if (_navMeshAgent == null)
            return;


        if (_travelling && _navMeshAgent.remainingDistance <= 2.0f)
		{
			_travelling = false;

			if (_patrolWaiting)
			{
				_waiting = true;
				_waitTimer = 1000f;
			}
			else
			{
				ChangePatrolPoint();
				SetDestination();
			}
		}

		if (_waiting)
		{
			_waitTimer += Time.deltaTime;
			if (_waitTimer >= _totalWaitTime)
			{
				_waiting = false;
               

                ChangePatrolPoint();
				SetDestination();
            }
		}
    }
 
	public void SetDestination()
	{
		if (_patrolPoints.Length >= 2)
		{
			Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
			Quaternion targetVectorDir = _patrolPoints[_currentPatrolIndex].transform.rotation;

			//Hopping motion
			//transform.LookAt(targetVector);

			// The step size is equal to speed times frame time.
			var step = (_navMeshAgent.angularSpeed) * Time.deltaTime;

			// Rotate our transform a step closer to the target's.
			transform.rotation = Quaternion.RotateTowards(transform.rotation, targetVectorDir, step);

			//_navMeshAgent.Move(transform.forward*Time.deltaTime);
			_navMeshAgent.SetDestination(targetVector);
			_travelling = true;
		}
        //else if (pursuing)
        //{
        //    Debug.Log("Chasing is Activated");
        //}
	}

	private void ChangePatrolPoint()
	{
		if (UnityEngine.Random.Range(0f,1f) <= _switchProbability)
		{
			_patrolForward = !_patrolForward;
		}

		if (_patrolForward)
		{
			_currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
		}
		else
		{
			if (--_currentPatrolIndex < 0)
			{
				_currentPatrolIndex = _patrolPoints.Length - 1;
			}
		}
	}
}
