using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeCheckDecision : DecisionNode
{
    protected override Node SelectChildNode()
    {
        if (ShopStats.instance.customerAtFront.age >= 18)
        {
            return childNodes[0];
        }
        else
        {
            return childNodes[1];
        }
    }
}
