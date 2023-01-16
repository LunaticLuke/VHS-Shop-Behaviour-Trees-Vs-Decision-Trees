using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

//Handles the collection of deliveries
public class StockDeliveryBehaviourLeaf : BehaviourTreeNode
{
    public Transform deliveryPoint;

    public Transform stockRoomPoint;

    NavMeshAgent agent;

    private DeliveryDrop.Delivery carryingItem;

    bool running = false;

    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    protected override void NodeFunction()
    {
     
        if (!running)
        {
            StartCoroutine(CollectDelivery());
            running = true;
        }
    }

    IEnumerator CollectDelivery()
    {
        //Moving to the point
        ShopStats.instance.currentTaskText.text = "Collecting Delivery";
        agent.SetDestination(deliveryPoint.position);
        yield return new WaitForSeconds(5);
        DeliveryDrop.instance.collectDelivery();
        carryingItem = DeliveryDrop.instance.currentDelivery;
        agent.SetDestination(stockRoomPoint.position);
        yield return new WaitForSeconds(5);
        StockManager.instance.addToStockRoom(carryingItem.deliveryItem.item.itemIndex, carryingItem.amount); //add new stock to stock room stock
        this.state = State.SUCCESS;
    }

    public override void ResetNode()
    {
        base.ResetNode();
        running = false;
    }
}
