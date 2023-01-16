using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This leaf node handles the customer going to the toilet
public class CustomerGoToiletBehaviour : BehaviourTreeNode
{
    public Transform toilet;

    Customer customer;

    NavMeshAgent agent;

    bool running = false;

    float distance = 0;

    bool ran = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        customer = this.GetComponent<Customer>();
    }

    private void Update()
    {
        //Running and ran stops it from being ran more than once
        if (running)
        {
            distance = Vector3.Distance(transform.position, toilet.position);
            if (distance <= 5 && !ran)
            {
                //If within range, they are on toilet
                ran = true;
                StartCoroutine(GoToToilet());
            }
        }
    }

    protected override void NodeFunction()
    {
        //Running and ran stops it from being ran more than once
        if (!running)
        {
            ShopStats.instance.LeaveQueue();
            agent.SetDestination(toilet.position);
            running = true;
        }
    }
    //A coroutine to handle timers
    IEnumerator GoToToilet()
    {
        yield return new WaitForSeconds(10);
        //After 10 seconds, they no longer need the toilet. This node is a success
        customer.needToilet = false;
        customer.ableToGoToToilet = false;
        customer.served = false;
        this.state = State.SUCCESS;
    }

    public override void ResetNode()
    {
        base.ResetNode();
        running = false;
        ran = false;
    }
}
