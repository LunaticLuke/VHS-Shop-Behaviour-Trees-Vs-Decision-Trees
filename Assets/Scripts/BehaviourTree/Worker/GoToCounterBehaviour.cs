using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Sends the worker to the cashier point
public class GoToCounterBehaviour : BehaviourTreeNode
{
    public Transform counter;
    NavMeshAgent agent;

    bool running = false;

    float distance = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (running)
        {
            distance = Vector3.Distance(transform.position, counter.position);
            //Debug.Log(distance);
            if (distance <= 1.25)
            {
                //When it has reached the destination, end the node
                this.state = State.SUCCESS;
            }
        }
    }
    protected override void NodeFunction()
    {
        if (!running)
        {
            agent.SetDestination(counter.position);
            ShopStats.instance.currentTaskText.text = "Going To Counter";
            running = true;
        }
    }

  

    public override void ResetNode()
    {
        base.ResetNode();
        running = false;
    }
}
