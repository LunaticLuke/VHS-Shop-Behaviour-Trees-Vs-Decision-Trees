using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrioritySelector : SelectorNode
{
    public List<int> priorityLevels;

    protected override void NodeFunction()
    {
        BehaviourTreeNode currentNodeToRun = null;
        int currentNodeIndex = -1;

        for(int i = 0; i < childNodes.Count;i++)
        {
            //If there isnt a node assigned yet
            if (currentNodeToRun == null)
            {
                if(childNodes[i].GetNodeState() != BehaviourTreeNode.State.FAILURE && childNodes[i].GetNodeState() != BehaviourTreeNode.State.SUCCESS)
                {
                    currentNodeToRun = childNodes[i];
                    currentNodeIndex = i;
                }
            }
            //If there is another node to compare this one to
            else
            {
                //If this current node is more of a priority than the one we had previously set
                if(priorityLevels[i] < priorityLevels[currentNodeIndex])
                {
                    if (childNodes[i].GetNodeState() != BehaviourTreeNode.State.FAILURE && childNodes[i].GetNodeState() != BehaviourTreeNode.State.SUCCESS)
                    {
                        currentNodeToRun = childNodes[i];
                        currentNodeIndex = i;
                    }
                }
            }
        }
       // Debug.Log(string.Format("Index Of Priority Is {0}",currentNodeIndex));
        //Ran all so this node is a success
        int failure = 0;
        foreach(BehaviourTreeNode node in childNodes)
        {
            if(node.GetNodeState() == State.FAILURE)
            {
                failure++;
            }
        }
        //Debug.Log(string.Format("{0} Failures", failure));
        if( failure == childNodes.Count)
        {
            this.state = State.FAILURE;
        }
        else if(currentNodeToRun == null)
        {
            Debug.Log("Successful");
            this.state = BehaviourTreeNode.State.SUCCESS;
        }
        else
        {
            
                currentNodeToRun.StartNode();
                currentNodeToRun.RunNode();
            
        }

    }
}
