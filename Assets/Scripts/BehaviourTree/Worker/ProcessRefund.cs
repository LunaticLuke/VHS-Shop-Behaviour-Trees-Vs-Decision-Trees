using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Handles a worker processing a refund
public class ProcessRefund : BehaviourTreeNode
{
   
    public Transform stockRoom;
    NavMeshAgent agent;

    bool running = false;

    float distance = 0;

    bool ran = false;

    StockManager.StockItem itemBeingReturned;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (running)
        {
            distance = Vector3.Distance(transform.position, stockRoom.position);
            if(distance <= 2 && !ran)
            {
                StartCoroutine(AtShelf());
                ran = true;
            }
        }
    }
    protected override void NodeFunction()
    {
        if (!running)
        {
            StartCoroutine(ProcessRefundFunction());
            running = true;
        }
    }

    IEnumerator ProcessRefundFunction()
    {
        yield return new WaitForSeconds(3);
        itemBeingReturned = ShopStats.instance.customerAtFront.itemToRefund;
        ShopStats.instance.customerAtFront.GetComponent<ReturningSomethingCustomerNode>().Return();
        ShopStats.instance.customerAtFront.served = true;
        agent.SetDestination(stockRoom.position);
 
    }

    IEnumerator AtShelf()
    {
        yield return new WaitForSeconds(3);
        StockManager.instance.addToStockRoom(itemBeingReturned.item.itemIndex, 1);
        this.state = State.SUCCESS;
    }

  

    public override void ResetNode()
    {
        base.ResetNode();
        running = false;
        ran = false;
    }
}
