using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
	NavMeshAgent nma;
	float origSpeed;
	private Shooting shootscript;
	private NPCSimplePatrol npcsp;
	public bool seen;

	public void targetFound()
	{
		shootscript.StartShooting();

		if (npcsp != null)
		{
			nma.speed = 0;
			nma.isStopped = true;
		}
	}

	public void targetNotFound()
	{
		shootscript.StopShooting();

		if (npcsp != null)
		{
			nma.isStopped = false;
			nma.speed = origSpeed;
			npcsp.SetDestination();
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		
		npcsp = GetComponent<NPCSimplePatrol>();
		nma = GetComponent<NavMeshAgent>();
		if (npcsp != null)
		{
			origSpeed = nma.speed;
		}

		shootscript = GetComponent<Shooting>();
	}
}
