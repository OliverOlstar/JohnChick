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

        prefab.GetComponent<MyModel>().myModel = GetComponent<MeshRenderer>();

        GetComponent<Follow>().target = prefab.transform;
        GetComponentInChildren<HoppingMovement>().speedSourceNav = prefab.GetComponent<NavMeshAgent>();
        
        if (patrolRoute)
        {
            NPCSimplePatrol npcSimplePatrol = prefab.GetComponent<NPCSimplePatrol>();
            Waypoints[] route = patrolRoute.GetComponentsInChildren<Waypoints>();
            npcSimplePatrol._patrolPoints = route;
        }
    }
}
