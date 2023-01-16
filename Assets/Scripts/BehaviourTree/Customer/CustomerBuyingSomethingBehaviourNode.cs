using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This node checks if the customer it is attached to is buying something
public class CustomerBuyingSomethingBehaviourNode : BehaviourTreeNode
{

    protected override void NodeFunction()
    {
        if(this.GetComponent<Customer>().buyingSomething)
        {
            Debug.Log("Buying Something");
            this.state = State.SUCCESS;
        }
        else
        {
            this.state = State.FAILURE;
        }
    }
}
