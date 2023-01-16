using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class checks if a customer has bought from the vending machine
public class BoughtFromVendingMachineBehaviourNode : BehaviourTreeNode
{
    Customer customer;

    // Start is called before the first frame update
    void Start()
    {
        customer = this.GetComponent<Customer>();
    }

    protected override void NodeFunction()
    {
        if(customer.boughtFromVendingMachine)
        {
            this.state = State.SUCCESS;
        }
        {
            this.state = State.FAILURE;
        }
    }

}
