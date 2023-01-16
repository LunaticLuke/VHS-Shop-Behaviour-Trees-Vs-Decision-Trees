using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceDecisionNode : DecisionNode
{
    public int chanceOfFirstNode;

    protected override Node SelectChildNode()
    {
        int rand = Random.Range(0, 100);
        if(rand <= chanceOfFirstNode)
        {
            return childNodes[0];
        }
        else
        {
            return childNodes[1];
        }
    }
}
