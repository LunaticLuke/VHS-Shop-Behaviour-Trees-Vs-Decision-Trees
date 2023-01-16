using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShopWorker : MonoBehaviour
{
    //NavMeshAgent component to navigate the shop
    public NavMeshAgent agent;
    //Do they need the toilet?
    public bool needsToilet = true;
    //Are they at the counter?
    public bool atCounter = false;

    void goToDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
}
