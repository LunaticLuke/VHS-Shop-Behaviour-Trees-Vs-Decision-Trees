using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks if the assigned worker needs the toilet
public class DoesWorkerNeedToilerBehaviour : BehaviourTreeNode
{
    protected override void NodeFunction()
    {
        if(this.GetComponent<ShopWorker>().needsToilet)
        {
            this.state = State.SUCCESS;
        }
        else
        {
            this.state = State.FAILURE;
        }
    }
}
