using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//handles the worker going to the toilet - same as customer just with worker instead
public class WorkerToiletBehaviourLeaf : BehaviourTreeNode
{
    public Transform toilet;

    NavMeshAgent agent;

    bool running = false;

    float distance = 0;

    bool ran = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (running)
        {
            distance = Vector3.Distance(transform.position, toilet.position);
            if (distance <= 5 && !ran)
            {
                ran = true;
                StartCoroutine(GoToToilet());
            }
        }
    }

    protected override void NodeFunction()
    {
        if (!running)
        {
            agent.SetDestination(toilet.position);
            running = true;
        }
    }

    IEnumerator GoToToilet()
    {
        ShopStats.instance.currentTaskText.text = "In Toilet";
        yield return new WaitForSeconds(10);
        this.GetComponent<ShopWorker>().needsToilet = false;
        this.state = State.SUCCESS;
    }

    public override void ResetNode()
    {
        base.ResetNode();
        running = false;
        ran = false;
    }
}
