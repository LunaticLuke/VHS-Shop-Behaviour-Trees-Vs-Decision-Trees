using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles the worker allowing the customer to go to the toilet
public class AllowCustomerToilet : BehaviourTreeNode
{
    protected override void NodeFunction()
    {
        ShopStats.instance.customerAtFront.ableToGoToToilet = true;
        ShopStats.instance.customerAtFront.served = true;
        this.state = State.SUCCESS;
    }
}
