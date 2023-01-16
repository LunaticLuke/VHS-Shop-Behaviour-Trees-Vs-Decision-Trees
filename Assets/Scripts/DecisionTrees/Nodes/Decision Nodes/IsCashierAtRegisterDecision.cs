using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCashierAtRegisterDecision : DecisionNode
{
    public ShopWorker worker;
    protected override Node SelectChildNode()
    {
        if(worker.atCounter)
        {
            return childNodes[0];
        }
        else
        {
            return childNodes[1];
        }
    }
}
