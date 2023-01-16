using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This class handles a customer's behaviour when a refund has been processed.
public class ReturningSomethingCustomerNode : BehaviourTreeNode
{

    Customer customer;
    NavMeshAgent agent;
    [HideInInspector]
    public bool served = false;
    bool running = false;


    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        customer = this.GetComponent<Customer>();
    }

    private void Update()
    {

    }

    protected override void NodeFunction()
    {
        //Debug.Log("Buying");
        running = true;

    }



    public void Return()
    {
        //No longer returning anything, can leave
        customer.returningSomething = false;
        ShopStats.instance.HappyCustomers += 1;
        ShopStats.instance.LeaveQueue();
        this.state = State.SUCCESS;
    }


    public override void ResetNode()
    {
        base.ResetNode();
        running = false;
    }
}
