using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This node has a random chance of sending the customer to the vending machine
public class GoingToVendingMachineBehaviourNode : BehaviourTreeNode
{

    int chanceOfVendingMachine = 10;

    protected override void NodeFunction()
    {
        Debug.Log("Going To Vending Machine?");
        int randomNumber = Random.Range(0,100);
        if(randomNumber >= 0 && randomNumber <= chanceOfVendingMachine)
        {
        Debug.Log("Yes");
            this.state = State.SUCCESS;
        }else
        {
        Debug.Log("No");
            this.state = State.FAILURE;
        }
    }
}
