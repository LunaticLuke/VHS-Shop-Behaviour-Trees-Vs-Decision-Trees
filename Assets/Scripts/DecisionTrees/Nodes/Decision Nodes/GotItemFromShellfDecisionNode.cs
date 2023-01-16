using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotItemFromShellfDecisionNode : DecisionNode
{
    protected override Node SelectChildNode()
    {
        if(GetComponent<Customer>().gotItemFromShelf)
        {
            Debug.Log("Gotten From Shelf");
            return childNodes[0];
        }else
        {
            Debug.Log("Hasnt gotten from shelf");
            return childNodes[1];
        }
    }
}
