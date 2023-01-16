using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourRootNode : MonoBehaviour
{
    public BehaviourTreeNode node;
    bool running = false;

    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }
    // Update is called once per frame
    void Update()
    {
        if (node != null)
        {
            if (running)
            {
               
                // Run the tree node
                BehaviourTreeNode.State rootNodeState = node.RunNode();

                // Print status message
                if (rootNodeState == BehaviourTreeNode.State.SUCCESS)
                {
                    Debug.Log("Tree has completed successfully. Can restart.");
                    running = false;
                    //Restart the behaviour tree as the root node has finished
                    Restart();
                }
                else if (rootNodeState == BehaviourTreeNode.State.FAILURE)
                {
                    Debug.Log("Tree has failed. Can restart.");
                    running = false;
                    //Restart the behaviour tree as the root node has finished
                    Restart();
                }
            }
    
        }
    }

    void Restart()
    {
        node.ResetNode();
        node.StartNode();
        running = true;
    }
}
