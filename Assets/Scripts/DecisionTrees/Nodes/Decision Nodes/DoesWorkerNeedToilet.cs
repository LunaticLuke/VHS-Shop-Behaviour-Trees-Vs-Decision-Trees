using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoesWorkerNeedToilet : DecisionNode
{

    public ShopWorker worker;

    protected override Node SelectChildNode()
    {
        if(worker.needsToilet)
        {
            return childNodes[0];
        }
        else
        {
            //Debug.Log("Doesnt need toilet");
            return childNodes[1];
        }
    }
}
