using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoesCustomerHaveIDNode : DecisionNode
{
    protected override Node SelectChildNode()
    {
        if (ShopStats.instance.customerAtFront.hasID)
        {
            return childNodes[0];
        }
        else
        {
            return childNodes[1];
        }
    }
}
