using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelector : SelectorNode
{
    protected override void NodeFunction()
    {
        BehaviourTreeNode node = null;
        int randomNumber = -1;

        //Is a node already running?
        for(int i  = 0; i < childNodes.Count;i++)
        {
            //Check if a node is already running first
            if(childNodes[i].GetNodeState() == BehaviourTreeNode.State.RUNNING)
            {
                node = childNodes[i];
                node.StartNode();
                node.RunNode();
                break;
            }
        }
        //Finding a random child node
        if (node == null)
        {
            //Random node
                randomNumber = Random.Range(0, childNodes.Count);
                node = childNodes[randomNumber];
                node.StartNode();
                BehaviourTreeNode.State childState = node.RunNode();
               
            
        }
        //Checking if all nodes have ran
        int complete = 0;
        foreach (BehaviourTreeNode childNode in childNodes)
        {
            if (childNode.GetNodeState() == State.FAILURE|| childNode.GetNodeState() == State.SUCCESS)
            {
                complete++;
            }
        }

        if(complete == childNodes.Count)
        {
            this.state = State.SUCCESS;
        }

    }
}
