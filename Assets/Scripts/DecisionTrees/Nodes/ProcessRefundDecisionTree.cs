using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProcessRefundDecisionTree : Node
{
    public Transform stockRoom;
    NavMeshAgent agent;
    float distance = 0;
    bool runningFunc = false;
    StockManager.StockItem itemBeingReturned;
    bool ran = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (running)
        {
            distance = Vector3.Distance(transform.position, stockRoom.position);
            if (distance <= 1.25 && !ran)
            {
                ran = true;
                StartCoroutine(AtShelf());
            }
        }
    }

    protected override void Run()
    {
        
            StartCoroutine(ProcessRefundFunction());
    }


    IEnumerator ProcessRefundFunction()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Issuing Refund");
        itemBeingReturned = ShopStats.instance.customerAtFront.itemToRefund;
        ShopStats.instance.customerAtFront.GetComponent<ReturnItemDecisionTree>().Return();
        ShopStats.instance.customerAtFront.served = true;
        agent.SetDestination(stockRoom.position);

    }

    IEnumerator AtShelf()
    {
        yield return new WaitForSeconds(3);
        StockManager.instance.addToStockRoom(itemBeingReturned.item.itemIndex, 1);
        ran = false;
        running = false;
        runningFunc = false;
        RootNode.instance.tree.setRunning(false);
    }
}
