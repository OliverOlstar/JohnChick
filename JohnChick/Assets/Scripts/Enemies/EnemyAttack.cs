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

	public GameObject actualPidgeon;
	public GameObject idleModel;
	public GameObject activeModel;

	public void targetFound()
	{
		if (gameObject.name == "Enemy(Pidgeon)")
		{
			activeModel.SetActive(true);
			idleModel.SetActive(false);
			//activeModel.transform.localEulerAngles.Set(0,180,0);
		}
		shootscript.StartShooting();

		if (npcsp != null)
		{
			nma.speed = 0;
			nma.isStopped = true;
		}
	}

	public void targetNotFound()
	{
		if (gameObject.name == "Enemy(Pidgeon)")
		{
			idleModel.SetActive(true);
			activeModel.SetActive(false);
		}
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
