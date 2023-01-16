using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallbackSelector : SelectorNode
{
    protected override void NodeFunction()
    {
        // Flag to see if at least one child node has run
        bool hasRunChildNode = false;
        bool alreadyRunning = false;

        // Iterate over each child node
        foreach (BehaviourTreeNode node in childNodes)
        {
            // Start Node - does nothing if already running
            node.StartNode();


            BehaviourTreeNode.State childState = node.RunNode();

            // If the child node has already failed, move to the next one
            if (childState == State.FAILURE)
                continue;

            // State we have run a child node - we are about to
            hasRunChildNode = true;

            // Run the node and check if it succeeds. If it does set this node to have succeeded
            if (childState == State.SUCCESS)
            {
                this.state = State.SUCCESS;
            }

            // Once a single child node has been run, break from the for loop
            break;
        }

        // If not child nodes have been run, this selector has failed as well
        if (!hasRunChildNode)
        {
            this.state = State.FAILURE;
        }
    }
}
