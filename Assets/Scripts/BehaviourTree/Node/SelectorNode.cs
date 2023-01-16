using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base class for all selectors. All it adds is the ability to reset child nodes via one function
public class SelectorNode : BehaviourTreeNode
{
    
    public List<BehaviourTreeNode> childNodes;



    public override void ResetNode()
    {
        base.ResetNode();
        foreach(BehaviourTreeNode child in childNodes)
        {
            child.ResetNode();
        }
    }
}
