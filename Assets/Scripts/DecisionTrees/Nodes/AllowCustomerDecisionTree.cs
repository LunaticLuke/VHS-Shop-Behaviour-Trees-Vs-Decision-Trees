using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Decision tree version of BT allowing a customer script - only difference is setting running to false rather than states.
public class AllowCustomerDecisionTree : Node
{
    protected override void Run()
    {
        ShopStats.instance.customerAtFront.ableToGoToToilet = true;
        ShopStats.instance.customerAtFront.served = true;
        //Debug.Log("Customer Can Go To Toilet");
        running = false;
        RootNode.instance.tree.setRunning(false);
    }
}
