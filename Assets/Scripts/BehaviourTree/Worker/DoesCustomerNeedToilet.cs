using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks if the customer needs the toilet from the worker's Point of view
public class DoesCustomerNeedToilet : BehaviourTreeNode
{
    protected override void NodeFunction()
    {
        if(ShopStats.instance.customerAtFront.needToilet)
        {
            this.state = State.SUCCESS;
        }
        else
        {
            this.state = State.FAILURE;
        }
    }
}
