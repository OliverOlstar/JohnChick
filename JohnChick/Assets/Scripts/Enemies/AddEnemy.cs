using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AddEnemy : MonoBehaviour
{
    [SerializeField] private GameObject myPrefab;
    [SerializeField] private Transform patrolRoute;
    
    void Start()
    {
        GameObject prefab = Instantiate(myPrefab);

        prefab.transform.position = transform.position;
        prefab.transform.rotation = transform.rotation;

        GetComponent<Follow>().target = prefab.transform;
        GetComponentInChildren<HoppingMovement>().speedSourceNav = prefab.GetComponent<NavMeshAgent>();

        NPCSimplePatrol npcSimplePatrol = prefab.GetComponent<NPCSimplePatrol>();
        Waypoints[] route = patrolRoute.GetComponentsInChildren<Waypoints>();

        npcSimplePatrol._patrolPoints = route;
    }
}
