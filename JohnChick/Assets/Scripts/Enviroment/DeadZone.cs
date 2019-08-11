using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeadZone : MonoBehaviour
{
	public GameManager gmanage;
    // Start is called before the first frame update
    void Start()
    {
		//gmanage = GetComponent<GameManager>();
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
        {
            gmanage.Respawn();
		}
	}
}
