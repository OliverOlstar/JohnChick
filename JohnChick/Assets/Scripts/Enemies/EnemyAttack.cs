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

	public float smooth = 200f;
	private Quaternion targetRotation;

	public void targetFound()
	{
		if (gameObject.name == "Enemy(Pidgeon)")
		{
			Debug.Log("BirdieIn");
			actualPidgeon = GameObject.Find("PidgeonModel");
			//activeModel = GameObject.Find("SHIT_HAWK_ATTACK_TEST");
			//idleModel = GameObject.Find("SHIT_HAWK_IDLE_TEST");
			targetRotation = Quaternion.LookRotation(-transform.forward, Vector3.up);

			actualPidgeon.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smooth * Time.deltaTime);

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
			Debug.Log("BirdieOut");
			actualPidgeon = GameObject.Find("PidgeonModel");
			//activeModel = GameObject.Find("SHIT_HAWK_ATTACK_TEST");
			//idleModel = GameObject.Find("SHIT_HAWK_IDLE_TEST");

			targetRotation = Quaternion.LookRotation(transform.forward, Vector3.up);

			actualPidgeon.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smooth * Time.deltaTime);

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
