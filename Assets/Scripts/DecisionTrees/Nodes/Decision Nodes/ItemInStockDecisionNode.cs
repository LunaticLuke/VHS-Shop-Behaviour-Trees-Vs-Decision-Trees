using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInStockDecisionNode : DecisionNode
{
    protected override Node SelectChildNode()
    {
        if (StockManager.instance.customerIsThereStock(GetComponent<Customer>().ShoppingList.item.itemIndex)) 
        {
            Debug.Log("Item Is In Stock");
            return childNodes[0];
        }
        else
        {
            Debug.Log("Item Isnt In Stock");
            return childNodes[1];
        }
    }
}
