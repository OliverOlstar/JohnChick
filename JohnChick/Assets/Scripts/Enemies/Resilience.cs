using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resilience : MonoBehaviour
{
    [Range(1,3)]public int resilience;
    public bool isEnemy;
	public bool isBullet;
	
	bool stunned;
    public GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>() ;
    }

    private void OnCollisionEnter(Collision c)
    {
		if (c.gameObject.GetComponent<Resilience>() != null)
		{
			if (c.gameObject.GetComponent<Resilience>().isEnemy)
			{
				int enemResilience = c.gameObject.GetComponent<Resilience>().resilience;
				if (resilience >= enemResilience)
				{
					gameManager.score += enemResilience * 5;
					//Death case
					//c.gameObject.SetActive(false);
					Destroy(c.gameObject);
				}
				if (enemResilience - resilience == 1)
				{
					gameManager.score += enemResilience * 5;
					//Stun case
					stunned = true;
				}

			}
		}
        
		else if (c.gameObject.tag=="Player"&& gameObject.GetComponent<Resilience>().isBullet)
		{

			c.gameObject.GetComponent<PlayerDeath>().KillPlayer(gameObject.GetComponent<Rigidbody>().velocity);


			//int enemResilience = c.gameObject.GetComponent<Resilience>().resilience;
			//if (resilience >= enemResilience)
			//{
				//gameManager.score += enemResilience * 5;
				//Death case
				//c.gameObject.SetActive(false);
				//Destroy(c.gameObject);
			//}
			//if (enemResilience - resilience == 1)
			//{
			//	gameManager.score += enemResilience * 5;
			//	//Stun case
			//	stunned = true;
			//}

		}
	}

	private void Update()
	{
		if (!stunned)
		{
			StopCoroutine(StunEffect());
		}
		else if (stunned)
		{
			StartCoroutine(StunEffect());
		}
	}

	IEnumerator StunEffect()
	{
		MonoBehaviour[] comps = GetComponents<MonoBehaviour>();

		foreach (MonoBehaviour c in comps)
		{
			c.enabled = false;
		}

		yield return new WaitForSecondsRealtime(3f);

		stunned = false;
	}


}
