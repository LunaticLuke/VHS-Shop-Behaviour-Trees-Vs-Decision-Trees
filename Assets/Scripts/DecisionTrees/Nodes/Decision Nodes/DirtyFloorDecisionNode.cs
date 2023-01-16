using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyFloorDecisionNode : DecisionNode
{
    protected override Node SelectChildNode()
    {
        if(ShopStats.instance.dirtyFloor)
        {
            return childNodes[0];
        }
        else
        {
            return childNodes[1];
        }
    }
}
