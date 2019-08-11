using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private GameManager GM;

    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        while (GM._score.Count > 0)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
            Instantiate(objects[GM._score[0]]);
            GM._score.Remove(0);
        }
    }
}
