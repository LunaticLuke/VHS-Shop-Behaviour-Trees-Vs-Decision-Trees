using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StockShelfLeafNode : Node
{
    public Transform ManagerPoint;

    public Transform stockRoomPoint;

    NavMeshAgent agent;

    int amountHeld;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    protected override void Run()
    {
        StartCoroutine(serveCustomer());
    }

    IEnumerator serveCustomer()
    {
        StockManager.StockItem itemToStock = StockManager.instance.currentItemThatNeedsStocked;
       ShopStats.instance.currentTaskText.text =  string.Format("Restocking {0}", itemToStock.item.name);
        agent.SetDestination(stockRoomPoint.position);
        yield return new WaitForSeconds(5);
        amountHeld = StockManager.instance.howManyUntilFullShelf(itemToStock.item.itemIndex);
        if(itemToStock.amountInStockRoom < amountHeld)
        {
            int diffInAmount = amountHeld - itemToStock.amountInStockRoom;
            amountHeld -= diffInAmount;
            if (!DeliveryDrop.instance.ordered)
            {
                StartCoroutine(InformManager());
            }
           
        }
        StockManager.instance.removeFromStockRoom(itemToStock.item.itemIndex,amountHeld);
        agent.SetDestination(StockManager.instance.currentItemThatNeedsStocked.pointToMoveTo.position);
        yield return new WaitForSeconds(5);
        StockManager.instance.addToShelf(itemToStock.item.itemIndex, amountHeld);
        running = false;
        RootNode.instance.tree.setRunning(false);
    }


    IEnumerator InformManager()
    {
        agent.SetDestination(ManagerPoint.position);
        ShopStats.instance.currentTaskText.text = "Ordering Stock";
        yield return new WaitForSeconds(5);
        DeliveryDrop.instance.orderDelivery(StockManager.instance.currentItemThatNeedsStocked, StockManager.instance.currentItemThatNeedsStocked.maxShelfCapacity * 2);
    }
}
