using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private GameManager GM;

    void Start()
    {
        StartCoroutine("Spawn", GM.Gets());
    }

    IEnumerator Spawn(List<int> x)
    {
        while (x.Count > 0)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
            Instantiate(objects[x[0]]);
            x.Remove(0);
        }
    }
}
