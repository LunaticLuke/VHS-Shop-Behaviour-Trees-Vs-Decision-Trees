using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerInQueueDecisionNode : DecisionNode
{
    protected override Node SelectChildNode()
    {
        if(this.GetComponent<Customer>().inQueue)
        {
            Debug.Log("In Queue");
            return childNodes[0];
        }
        else
        {
            
                Debug.Log("Isnt In Queue");

                return childNodes[1];
        }
    }
}
