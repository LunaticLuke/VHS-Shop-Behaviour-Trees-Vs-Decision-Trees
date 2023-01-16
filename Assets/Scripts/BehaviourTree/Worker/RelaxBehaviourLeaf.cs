using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
//Handles the relaxing behavior
public class RelaxBehaviourLeaf : BehaviourTreeNode
{

    public Transform pointToMoveTo;

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
            StartCoroutine(Relax());
            running = true;
        }
    }

    IEnumerator Relax()
    {
        StockManager.instance.counting = false;
        //Relax for 15 seconds
        agent.SetDestination(pointToMoveTo.position);
        ShopStats.instance.currentTaskText.text = "Relaxing";
        yield return new WaitForSeconds(15);
        this.state = State.SUCCESS;
    }

    public override void ResetNode()
    {
        base.ResetNode();
        running = false;
    }
}
