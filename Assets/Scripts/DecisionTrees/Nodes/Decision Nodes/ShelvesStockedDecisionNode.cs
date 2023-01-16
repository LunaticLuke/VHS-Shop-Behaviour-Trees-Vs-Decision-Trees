using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelvesStockedDecisionNode : DecisionNode
{
    protected override Node SelectChildNode()
    {
        if(StockManager.instance.shelfNeedingStocked())
        {
            return childNodes[0];
        }
        else
        {
            return childNodes[1];
        }
    }
}
