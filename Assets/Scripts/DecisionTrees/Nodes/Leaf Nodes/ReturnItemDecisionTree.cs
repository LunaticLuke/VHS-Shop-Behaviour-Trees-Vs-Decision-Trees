using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Decision tree version of BT returning script - only difference is setting running to false rather than states.
public class ReturnItemDecisionTree : Node
{
    Customer customer;
    NavMeshAgent agent;
    [HideInInspector]
    public bool served = false;
    bool ran = false;


    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        customer = this.GetComponent<Customer>();
    }

    protected override void Run()
    {
    }

    public void Return()
    {
        Debug.Log("Receiving Refund");
        customer.returningSomething = false;
        customer.inQueue = false;
        ShopStats.instance.LeaveQueue();
        ShopStats.instance.HappyCustomers += 1;
        ran = false;
        running = false;
        GetComponent<CustomerRootNode>().tree.setRunning(false);
    }
}
