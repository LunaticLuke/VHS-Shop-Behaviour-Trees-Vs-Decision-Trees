using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Decision tree version of BT delivery script - only difference is setting running to false rather than states.
public class DeliveryLeafNode : Node
{

    public Transform deliveryPoint;

    public Transform stockRoomPoint;

    NavMeshAgent agent;

    private DeliveryDrop.Delivery carryingItem;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    protected override void Run()
    {
        StartCoroutine(CollectDelivery());
    }

    IEnumerator CollectDelivery()
    {
        ShopStats.instance.currentTaskText.text = "Collecting Delivery";
        agent.SetDestination(deliveryPoint.position);
        yield return new WaitForSeconds(5);
        DeliveryDrop.instance.collectDelivery();
        carryingItem = DeliveryDrop.instance.currentDelivery;
        agent.SetDestination(stockRoomPoint.position);
        yield return new WaitForSeconds(5);
        StockManager.instance.addToStockRoom(carryingItem.deliveryItem.item.itemIndex, carryingItem.amount);
        running = false;
        RootNode.instance.tree.setRunning(false);
    }
}
