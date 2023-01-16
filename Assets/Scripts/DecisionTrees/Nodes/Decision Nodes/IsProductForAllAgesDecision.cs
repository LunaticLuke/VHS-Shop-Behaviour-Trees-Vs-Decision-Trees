using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsProductForAllAgesDecision : DecisionNode
{
    protected override Node SelectChildNode()
    {
        if (!ShopStats.instance.customerAtFront.ShoppingList.item.ageRestricted)
        {
            return childNodes[0];
        }
        else
        {
            return childNodes[1];
        }
    }
}
