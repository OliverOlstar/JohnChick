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

	private void OnTiggerEnter(Collider other)
	{
        Debug.Log("Call 1");

		if (other.CompareTag("Player"))
        {
            Debug.Log("Call 2");
            gmanage.Respawn();
		}
	}
}
