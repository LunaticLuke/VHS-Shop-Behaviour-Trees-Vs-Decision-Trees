using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Decision tree version of BT Leave script - only difference is setting running to false rather than states.
public class LeaveLeafNode : Node
{
    NavMeshAgent agent;

    public Transform leavingPoint;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();   
    }

    protected override void Run()
    {
        StartCoroutine(Leave());
    }

    IEnumerator Leave()
    {
        Debug.Log("Leave Leaf Node");
        agent.SetDestination(leavingPoint.position);
        yield return new WaitForSeconds(10);
        if (this.GetComponent<Customer>().inQueue)
        {
            this.GetComponent<Customer>().inQueue = false;
            ShopStats.instance.LeaveQueue();
        }
        ShopStats.instance.LeaveShop(this.GetComponent<Customer>());
        running = false;
        gameObject.SetActive(false);
    }

    
}
