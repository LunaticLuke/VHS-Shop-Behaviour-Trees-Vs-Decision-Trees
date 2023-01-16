using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

//The behvaiour of ordering stock
public class OrderStockBehaviourLeaf : BehaviourTreeNode
{
    public Transform pointToMoveTo;

    NavMeshAgent agent;

    bool running = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    protected override void NodeFunction()
    {
       
        if (!running)
        {
            StartCoroutine(InformManager());
            running = true;
        }
    }

    IEnumerator InformManager()
    {
        //Moving to order point and waiting then triggering an order
        agent.SetDestination(pointToMoveTo.position);
        ShopStats.instance.currentTaskText.text = "Ordering Stock";
        yield return new WaitForSeconds(5);
        DeliveryDrop.instance.orderDelivery(StockManager.instance.currentItemThatNeedsStocked, StockManager.instance.currentItemThatNeedsStocked.maxShelfCapacity * 2);
        this.state = State.SUCCESS;
    }

    public override void ResetNode()
    {
        base.ResetNode();
        running = false;
    }
}
