using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RelaxLeafNode : Node
{
    public Transform pointToMoveTo;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected override void Run()
    {
      
        StartCoroutine(Relax());
    }

    IEnumerator Relax()
    {
        StockManager.instance.counting = false;
        agent.SetDestination(pointToMoveTo.position);
        ShopStats.instance.currentTaskText.text = "Relaxing";
        yield return new WaitForSeconds(15);
        running = false;
        RootNode.instance.tree.setRunning(false);
    }
}
