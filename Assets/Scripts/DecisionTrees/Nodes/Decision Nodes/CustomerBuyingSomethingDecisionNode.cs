using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBuyingSomethingDecisionNode : DecisionNode
{
    protected override Node SelectChildNode()
    {
       
        if(GetComponent<Customer>().buyingSomething)
        {
            //Debug.Log("Buying Something");
            return childNodes[0];
        }
        else
        {
            //Debug.Log("Not Buying Anything");
            return childNodes[1];
        }
    }
   
}
