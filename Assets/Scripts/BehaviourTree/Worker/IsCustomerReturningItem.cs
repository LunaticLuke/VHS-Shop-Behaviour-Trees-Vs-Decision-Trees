using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks if a customer is returning something
public class IsCustomerReturningItem : BehaviourTreeNode
{
    protected override void NodeFunction()
    {
        if (ShopStats.instance.customerAtFront.returningSomething)
        {
            this.state = State.SUCCESS;
        }
        else
        {
            this.state = State.FAILURE;
        }
    }
}
