using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks if any shelf needs restocking
public class DoesItNeedRestockNode : BehaviourTreeNode
{
    protected override void NodeFunction()
    {
        
        if (StockManager.instance.shelfNeedingStocked())
        {
            this.state = State.SUCCESS;
       
        }
        else
        {
          

            this.state = State.FAILURE;
        }
    }
}
