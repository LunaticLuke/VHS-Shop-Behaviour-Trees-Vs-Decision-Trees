using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//DT base node
public class Node : MonoBehaviour
{
    protected bool running = false;



    public void ExecuteNode()
    {
        //Tracks whether running
        running = true;
        Run();
    }

    public void setRunning(bool boolToSet)
    {
        running = boolToSet;
    }

    protected virtual void Run()
    {

    }

    public bool isNodeRunning()
    {
        return running;
    }
 
}
