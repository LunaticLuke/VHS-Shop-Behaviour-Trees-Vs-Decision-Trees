using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Decision tree version of BT ordering stock script - only difference is setting running to false rather than states.
public class InformManagerLeafNode : Node
{


    public Transform pointToMoveTo;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    protected override void Run()
    {
        StartCoroutine(InformManager());
    }

    IEnumerator InformManager()
    {
        agent.SetDestination(pointToMoveTo.position);
        ShopStats.instance.currentTaskText.text = "Ordering Stock";
        yield return new WaitForSeconds(5);
        DeliveryDrop.instance.orderDelivery(StockManager.instance.currentItemThatNeedsStocked, StockManager.instance.currentItemThatNeedsStocked.maxShelfCapacity * 2);
        running = false;
        RootNode.instance.tree.setRunning(false);
    }
}
