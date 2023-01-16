using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCustomerBuyingSomethingDecisionNode : DecisionNode
{
    protected override Node SelectChildNode()
    {
        if(ShopStats.instance.customerAtFront.buyingSomething)
        {
            return childNodes[0];
        }
        else
        {
            return childNodes[1];
        }
    }

}
