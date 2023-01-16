using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerRefundDecisionNode : DecisionNode
{
    protected override Node SelectChildNode()
    {
        if(this.GetComponent<Customer>().returningSomething)
        {
            Debug.Log("Is Refunding");
            return childNodes[0];
        }
        else
        {
           // Debug.Log("Isnt Refunding");

            return childNodes[1];
        }
    }
}
