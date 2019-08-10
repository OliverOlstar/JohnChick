using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resilience : MonoBehaviour
{
    [Range(1,3)]public int resilience;
    public bool isEnemy;
    public GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>() ;
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.GetComponent<Resilience>().isEnemy)
        {
            int enemResilience = c.gameObject.GetComponent<Resilience>().resilience;
            if( resilience >= enemResilience)
            {
                gameManager.score += enemResilience * 5;
                c.gameObject.SetActive(false);
            }
        }
    }
}
