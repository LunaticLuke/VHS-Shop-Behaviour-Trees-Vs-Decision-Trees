using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class checks if an item is in stock
public class IsItemInSTockBehaviourNode : BehaviourTreeNode
{
    protected override void NodeFunction()
    {
        if(StockManager.instance.shopStock[this.GetComponent<Customer>().ShoppingList.item.itemIndex].amountOnShelf > 0)
        {
            this.state = State.SUCCESS;
            Debug.Log("IS in stock");
        }
        else
        {
            this.state = State.FAILURE;
        }
    }
}
