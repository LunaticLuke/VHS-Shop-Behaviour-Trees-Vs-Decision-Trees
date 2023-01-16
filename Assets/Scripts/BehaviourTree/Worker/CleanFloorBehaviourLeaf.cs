using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

//The worker's cleaning floor behaviour
public class CleanFloorBehaviourLeaf : BehaviourTreeNode
{
    public Transform[] pointsToMoveTo;

    NavMeshAgent agent;

    bool running = false;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected override void NodeFunction()
    {
        if (!running)
        {
            StartCoroutine(CleanFloor());
            running = true;
        }
    }

    IEnumerator CleanFloor()
    {
        //Go point to point and wait
        ShopStats.instance.currentTaskText.text = "Cleaning Floor";
        for (int i = 0; i < pointsToMoveTo.Length; i++)
        {
            agent.SetDestination(pointsToMoveTo[i].position);
            yield return new WaitForSeconds(5);
        }
        ShopStats.instance.dirtyFloor = false;
        this.state = State.SUCCESS;
    }


}
