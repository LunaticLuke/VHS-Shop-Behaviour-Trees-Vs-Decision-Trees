using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This node handles the customer leaving the scene
public class LeaveLeafBehaviourNode : BehaviourTreeNode
{
    NavMeshAgent agent;

    public Transform leavingPoint;

    bool running = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    protected override void NodeFunction()
    {
        if(!running)
        {
            StartCoroutine(Leave());
            running = true;
        }
    }

    IEnumerator Leave()
    {
        agent.SetDestination(leavingPoint.position);
        yield return new WaitForSeconds(10);
        if (this.GetComponent<Customer>().inQueue)
        {
            //Ensure they have left the queue
            this.GetComponent<Customer>().inQueue = false;
            ShopStats.instance.LeaveQueue();
        }
        //Delete them from the scene
        ShopStats.instance.LeaveShop(this.GetComponent<Customer>());
        this.state = State.SUCCESS;
        Destroy(this);
    }

    public override void ResetNode()
    {
        base.ResetNode();
        running = false;
    }
}
