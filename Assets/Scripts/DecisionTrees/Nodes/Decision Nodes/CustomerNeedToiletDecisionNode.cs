using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerNeedToiletDecisionNode : DecisionNode
{
    protected override Node SelectChildNode()
    {
        if(this.GetComponent<Customer>().needToilet)
        {
            return childNodes[0];
        }
        else
        {
            return childNodes[1];
        }
    }
}
