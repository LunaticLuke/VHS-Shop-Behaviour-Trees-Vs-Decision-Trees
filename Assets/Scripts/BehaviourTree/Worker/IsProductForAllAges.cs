using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks if the item being bought is age restricted
public class IsProductForAllAges : BehaviourTreeNode
{
    protected override void NodeFunction()
    {
        //If item isnt age restricted, no limits on it
        if(!ShopStats.instance.customerAtFront.ShoppingList.item.ageRestricted)
        {
            Debug.Log("Item Isn't Age Restricted");
            this.state = State.SUCCESS;
        }
        else
        {
            Debug.Log("Item Is Age Restricted");
            this.state = State.FAILURE;
        }
    }
}
