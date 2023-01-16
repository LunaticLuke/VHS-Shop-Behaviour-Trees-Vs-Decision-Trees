using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//This class runs when a customer buys something within the behavior tree
public class BuyBehaviourLeafNode : BehaviourTreeNode
{
    //Storing references to relevant components
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

    
    //Called when the customer is served when buying something
    public void Served()
    {
        //If they aren't returning anything, leave the queue
        if (!customer.returningSomething)
        {
            ShopStats.instance.LeaveQueue();
        }
        else
        {
            //Otherwise stay in the queue
            customer.served = false;
        }
        //No longer buying anything
        customer.buyingSomething = false;
        //A happy customer
        ShopStats.instance.HappyCustomers += 1;
        //Mark the BT node as a success
        this.state = State.SUCCESS;
    }
    //Refused service due to ID
    public void Refused()
    {
        if (!customer.returningSomething)
        {
            ShopStats.instance.LeaveQueue();
        }
        customer.buyingSomething = false;
        //Mark BT node as failure
        this.state = State.FAILURE;
    }
  

    public override void ResetNode()
    {
        base.ResetNode();
        running = false;
    }


}
