using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class checks if the customer is getting a refund
public class IsCustomerReturningSomethingNode : BehaviourTreeNode
{
    protected override void NodeFunction()
    {
        if(this.GetComponent<Customer>().returningSomething)
        {
            this.state = State.SUCCESS;
        }
        else
        {
            this.state = State.FAILURE;
        }
    }
}
