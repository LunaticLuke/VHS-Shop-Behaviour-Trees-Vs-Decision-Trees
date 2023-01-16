using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks if the shop has a dirty floor
public class IsShopDirtyBehaviourLeaf : BehaviourTreeNode
{
    protected override void NodeFunction()
    {
        if(ShopStats.instance.dirtyFloor)
        {
            this.state = State.SUCCESS;
        }
        else
        {
            this.state = State.FAILURE;
        }
    }
}
