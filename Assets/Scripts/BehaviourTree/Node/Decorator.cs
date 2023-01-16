using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This decorator inverts the result of its child node
public class Decorator : SelectorNode
{
    //This node will invert the result of its child
    protected override void NodeFunction()
    {
        BehaviourTreeNode node = childNodes[0];
        node.StartNode();

        State childState = node.RunNode();

        if(childState == State.SUCCESS)
        {
            this.state = State.FAILURE;
        }else if(childState == State.FAILURE)
        {
            this.state = State.SUCCESS;
        }
    }
}
