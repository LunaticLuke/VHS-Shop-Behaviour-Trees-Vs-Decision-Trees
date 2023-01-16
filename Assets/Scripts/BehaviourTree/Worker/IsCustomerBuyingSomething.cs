using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks if the customer at front of queue is buying something
public class IsCustomerBuyingSomething : BehaviourTreeNode
{
    protected override void NodeFunction()
    {
        if(ShopStats.instance.customerAtFront.buyingSomething)
        {
            Debug.Log("Customer Is Buying Something");
            this.state = State.SUCCESS;
        }
        else
        {
            this.state = State.FAILURE;
            Debug.Log("Customer Isn't Buying Something");

        }
    }
}
