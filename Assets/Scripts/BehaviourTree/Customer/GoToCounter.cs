using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This class sends the attached customer to the queue
public class GoToCounter : BehaviourTreeNode
{
    public Transform counter;
    NavMeshAgent agent;
    Customer customer;


    bool running = false;

    float distance = 0;

    bool ran = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        customer = GetComponent<Customer>();
    }
    private void Update()
    {
        if (running)
        {
            distance = Vector3.Distance(transform.position, counter.position);
            //Debug.Log(distance);
            if (distance <= 1.25 && !ran)
            {
                //They have arrived at counter so can join the queue
                ran = true;
                ShopStats.instance.JoinQueue(customer);
            }
            if(customer.served)
            {
                //Once served, this is a success.
                this.state = State.SUCCESS;
            }
        }
    }
    protected override void NodeFunction()
    {
        if (!running)
        {
            //Send the navmesh agent to the counter
            agent.SetDestination(counter.position);
            running = true;
        }
    }



    public override void ResetNode()
    {
        base.ResetNode();
        running = false;
        ran = false;
    }
}
