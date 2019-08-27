using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSave : MonoBehaviour
{
	public float force;
    public int me = 0;

	private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
            ScoreCont._score.Add(me);
            StartCoroutine("MoveUp");
			Destroy(gameObject, 1);
		}
	}

    private void OnDestroy()
    {
        StopCoroutine("MoveUp");
    }

    private IEnumerator MoveUp()
    {
        while (transform.position.y < 50)
        {
            yield return null;
            transform.position += Vector3.up * force * Time.deltaTime;
        }
    }
}
