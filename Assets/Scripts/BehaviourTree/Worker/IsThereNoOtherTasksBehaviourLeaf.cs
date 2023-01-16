using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks if there is literally nothing left to do within the store
public class IsThereNoOtherTasksBehaviourLeaf : BehaviourTreeNode
{
    protected override void NodeFunction()
    {
        if (!ShopStats.instance.dirtyFloor && !ShopStats.instance.customerAtRegister && !StockManager.instance.shelfNeedingStocked() && !ShopStats.instance.deliveryHere)
        {
            this.state = State.SUCCESS;
        }
        else
        {
            this.state = State.FAILURE;
        }
    }
}
