using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryDecisionNode : DecisionNode
{

    protected override Node SelectChildNode()
    {
        if(ShopStats.instance.deliveryHere)
        {
            return childNodes[0];
        }else
        {
            return childNodes[1];
        }
    }

}
