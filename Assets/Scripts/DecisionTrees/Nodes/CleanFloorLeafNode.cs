using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Decision tree version of BT floor script - only difference is setting running to false rather than states.
public class CleanFloorLeafNode : Node
{

    public Transform[] pointsToMoveTo;

    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected override void Run()
    {
        StartCoroutine(CleanFloor());
    }

    IEnumerator CleanFloor()
    {
        ShopStats.instance.currentTaskText.text = "Cleaning Floor";
        for (int i = 0; i < pointsToMoveTo.Length; i++)
        {
            agent.SetDestination(pointsToMoveTo[i].position);
            yield return new WaitForSeconds(5);
        }
        running = false;
        ShopStats.instance.dirtyFloor = false;
        RootNode.instance.tree.setRunning(false);
    }
}
