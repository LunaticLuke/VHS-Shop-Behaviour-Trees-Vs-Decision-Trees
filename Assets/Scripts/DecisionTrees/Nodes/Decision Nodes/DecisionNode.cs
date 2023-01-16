using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionNode : Node
{
    
    public List<Node> childNodes;

    protected override void Run()
    {
        Node childNode = SelectChildNode();
        if(childNode != null)
        {
            childNode.ExecuteNode();
        }
        else
        {
            Debug.Log("Child Is Null. Tree Will Exit");
        }
    }

    protected virtual Node SelectChildNode()
    {
        return null;
    }

   
}
