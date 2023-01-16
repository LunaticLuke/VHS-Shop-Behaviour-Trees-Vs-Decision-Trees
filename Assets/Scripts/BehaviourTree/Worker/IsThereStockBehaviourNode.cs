using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks if there is stock in the stock room of a item
public class IsThereStockBehaviourNode : BehaviourTreeNode
{
    protected override void NodeFunction()
    {
        Debug.Log("Is an order needed");
        if (!StockManager.instance.ItemInStockRoom())
        {
            this.state = State.SUCCESS;
        }
        else
        {
            this.state = State.FAILURE;
        }
    }
}
