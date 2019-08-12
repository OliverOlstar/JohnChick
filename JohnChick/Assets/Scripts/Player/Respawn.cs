using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    [SerializeField] private float respawnDelay = 1f;

    void Start()
    {
        StartCoroutine("respawnDelayRoutine");
    }

    IEnumerator respawnDelayRoutine()
    {
        yield return new WaitForSeconds(respawnDelay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(Application.loadedLevel);
    }
}
