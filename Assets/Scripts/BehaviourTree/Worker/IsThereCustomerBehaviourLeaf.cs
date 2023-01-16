using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks if there is a customer at the counter
public class IsThereCustomerBehaviourLeaf : BehaviourTreeNode
{

    protected override void NodeFunction()
    {    
        if(ShopStats.instance.customerAtRegister)
        {
            this.state = State.SUCCESS;
        }
        else
        {
            this.state = State.FAILURE;
        }
    }
}
