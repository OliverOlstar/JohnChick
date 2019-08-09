using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool is_Moving = true;
    private int currentTarget = 2;
    private Transform[] childPositions;         //array of children
    private Transform movingPlatform;     // private prefab
    private int moveDirection = 1;

    [SerializeField] private bool pingPong = false;

    [Space]
    public float waitToGoBack;
    public float platformSpeed = 4f;
    
    private float distanceTo;
    // Start is called before the first frame update
    void Start()
    {
        childPositions = GetComponentsInChildren<Transform>();
        movingPlatform = childPositions[1];
    }

    // Update is called once per frame
    private void Update()
    {
        if (is_Moving)
        {
            movingPlatform.position = Vector3.MoveTowards(movingPlatform.position, childPositions[currentTarget].position, platformSpeed * Time.deltaTime);
            
            distanceTo = Vector3.Distance(movingPlatform.position, childPositions[currentTarget].position);
            if (distanceTo <= 0.1f)
            {                
                if (pingPong == false)
                {
                   
                    currentTarget++;
                    if (currentTarget == childPositions.Length)
                        currentTarget = 2;
                }
                else
                {
                    if (currentTarget == childPositions.Length -1)
                    {
                        moveDirection = -1;
                    }
                    else if (currentTarget == 2)
                    {
                        moveDirection = 1;
                    }

                    currentTarget += moveDirection;
                }

                StartCoroutine(WaitToGoBack());
            }
        }
    }

    private IEnumerator WaitToGoBack()
    {
        is_Moving = false;
        yield return new WaitForSeconds(waitToGoBack);
        is_Moving = true;
    }
}
