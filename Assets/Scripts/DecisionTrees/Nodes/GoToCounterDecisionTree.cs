using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Decision tree version of BT counter script - only difference is setting running to false rather than states.
public class GoToCounterDecisionTree : Node
{
    public Transform cashierPoint;

    NavMeshAgent agent;

    float distance;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, cashierPoint.position);
        //Debug.Log(distance);
        if (distance <= 1.25 && running)
        {
            running = false;
            RootNode.instance.tree.setRunning(false);
            this.GetComponent<ShopWorker>().atCounter = true;
        }
        else
        {
            this.GetComponent<ShopWorker>().atCounter = false;
        }
    }

    protected override void Run()
    {
        agent.SetDestination(cashierPoint.position);
        ShopStats.instance.currentTaskText.text = "Going To Counter";
    }

   

}
