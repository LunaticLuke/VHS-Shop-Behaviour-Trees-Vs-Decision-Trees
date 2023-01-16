using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoesCustomerNeedToiletDecision : DecisionNode
{
    protected override Node SelectChildNode()
    {
        if(ShopStats.instance.customerAtFront.needToilet)
        {
            return childNodes[0];
        }
        else
        {
            return childNodes[1];
        }
    }
}
