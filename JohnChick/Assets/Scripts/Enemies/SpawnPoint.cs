using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;
    private GameManager GM;

    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        StartCoroutine("SpawnDelay");
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("Spawn", GM._score);
    }

    IEnumerator Spawn(List<int> x)
    {
        foreach(int saved in x)
        {
            GameObject obj = Instantiate(objects[saved]);
            obj.transform.position = transform.position + new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
            obj.transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            yield return new WaitForSeconds(Random.Range(0.4f, 0.9f));
        }
    }
}
