using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks if there is a delivery outside
public class IsThereDeliveryLeaf : BehaviourTreeNode
{
    protected override void NodeFunction()
    {
        //Debug.Log("Is there a delivery?");
        if(ShopStats.instance.deliveryHere)
        {
            this.state = State.SUCCESS;
        }
        else
        {
            this.state = State.FAILURE;
        }
    }
}
