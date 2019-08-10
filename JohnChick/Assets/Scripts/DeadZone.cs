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
		gmanage = GetComponent<GameManager>();
    }

	private void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag=="Player")
		{
			gmanage.Respawn();
		}
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
