using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeNode : MonoBehaviour
{

    //The states that the nodes can be set to
    public enum State { WAITING, RUNNING, SUCCESS,FAILURE}
    //Initialise the state
    protected State state = State.WAITING;

  
    public BehaviourTreeNode.State RunNode()
    {
        if(state == State.RUNNING)
        {
            NodeFunction();
        }

        return state;
    }

    protected virtual void NodeFunction()
    {
        // Do nothing, base class which needs different sections for selectors and leaf nodes
    }

    public virtual void ResetNode()
    {
        state = State.WAITING;
    }

    public void StartNode()
    {
        if(state == State.WAITING)
        {
            state = State.RUNNING;
        }
    }

    public BehaviourTreeNode.State GetNodeState()
    {
        return state;
    }

    public virtual void ForceStateChange(State newState)
    {
        // Allow for other nodes for force a state change. Make this virtual so it can be overwritten with instance specific code
        state = newState;
    }

}
