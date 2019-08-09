using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
	NavMeshAgent nma;
	float origSpeed;
	private Shooting shootscript;
	bool shootit = false;
	bool loopy = false;
	public bool seen;
	public void targetFound()
	{
		Debug.Log("Target Found!");


		shootit = true;
		if (shootit && !loopy)
		{
			shootscript.StartShooting();
			loopy = true;
		}
		//shootscript.StartShooting();

		
	}

	public void targetNotFound()
	{

		shootit = false;

		shootscript.StopShooting();
		loopy = false;

		
	}



	// Start is called before the first frame update
	void Start()
    {
		nma = GetComponent<NavMeshAgent>();
		origSpeed = nma.speed;

		shootscript = GetComponent<Shooting>();
	}

    // Update is called once per frame
    void Update()
    {
		if (seen)
		{
			
			targetFound();
			nma.speed = 0;
			nma.isStopped = true;
			
			//break;
			//continue;
		}
		else
		{
			Debug.Log("***");
			
			targetNotFound();
			nma.isStopped = false;
			nma.speed = origSpeed;
		}
	}
}
