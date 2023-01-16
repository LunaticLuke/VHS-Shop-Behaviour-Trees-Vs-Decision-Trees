using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsThereStockDecisionNode : DecisionNode
{


    protected override Node SelectChildNode()
    {
        if(StockManager.instance.ItemInStockRoom())
        {
            return childNodes[0];
        }
        else
        {
            return childNodes[1];
        }
    }
}
