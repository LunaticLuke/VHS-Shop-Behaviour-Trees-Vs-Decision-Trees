using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCustomerWantingRefundDecision : DecisionNode
{
    protected override Node SelectChildNode()
    {
        if (ShopStats.instance.customerAtFront.returningSomething)
        {
            return childNodes[0];
        }
        else
        {
            return childNodes[1];
        }
    }
}
