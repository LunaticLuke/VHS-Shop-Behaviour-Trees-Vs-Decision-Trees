using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class checks whether the customer it is attached to needs the toilet
public class CustomerNeedToiletNode : BehaviourTreeNode
{
    protected override void NodeFunction()
    {
        if(this.GetComponent<Customer>().needToilet)
        {
            this.state = State.SUCCESS;
        }
        else { this.state = State.FAILURE; }
    }
}
