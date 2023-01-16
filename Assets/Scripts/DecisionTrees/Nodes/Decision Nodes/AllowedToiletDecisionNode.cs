using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowedToiletDecisionNode : DecisionNode
{
    protected override Node SelectChildNode()
    {
        if (this.GetComponent<Customer>().ableToGoToToilet)
        {
            return childNodes[0];
        }
        else
        {
            return childNodes[1];
        }
    }
}
