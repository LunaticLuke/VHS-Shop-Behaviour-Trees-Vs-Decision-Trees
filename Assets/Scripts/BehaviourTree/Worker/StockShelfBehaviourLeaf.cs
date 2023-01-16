using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

//Stocking shelf behavior
public class StockShelfBehaviourLeaf : BehaviourTreeNode
{
    public Transform ManagerPoint;

    public Transform stockRoomPoint;

    NavMeshAgent agent;

    int amountHeld;

    bool running = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    protected override void NodeFunction()
    {
        // Debug.Log("Stocking Shelf");

        if (!running)
        {
            StartCoroutine(serveCustomer());
            running = true;
        }
    }


    IEnumerator serveCustomer()
    {
        StockManager.StockItem itemToStock = StockManager.instance.currentItemThatNeedsStocked; //Find out which stock item it is
        ShopStats.instance.currentTaskText.text = string.Format("Restocking {0}", itemToStock.item.name);
        agent.SetDestination(stockRoomPoint.position);
        yield return new WaitForSeconds(5);
        amountHeld = StockManager.instance.howManyUntilFullShelf(itemToStock.item.itemIndex); //Find out how many are needed to fill shelf
        if (itemToStock.amountInStockRoom < amountHeld) //If there isnt enough, order some and use the rest to fill the shelf as best as possible
        {
            int diffInAmount = amountHeld - itemToStock.amountInStockRoom;
            amountHeld -= diffInAmount;
            if (!DeliveryDrop.instance.ordered)
            {
                StartCoroutine(InformManager());
            }

        }
        StockManager.instance.removeFromStockRoom(itemToStock.item.itemIndex, amountHeld); //Remove from stock room level
        agent.SetDestination(StockManager.instance.currentItemThatNeedsStocked.pointToMoveTo.position);
        yield return new WaitForSeconds(5);
        StockManager.instance.addToShelf(itemToStock.item.itemIndex, amountHeld); //Add to actual shelf numbers
        this.state = State.SUCCESS;
    }


    IEnumerator InformManager()
    {
        agent.SetDestination(ManagerPoint.position);
        ShopStats.instance.currentTaskText.text = "Ordering Stock";
        yield return new WaitForSeconds(5);
        DeliveryDrop.instance.orderDelivery(StockManager.instance.currentItemThatNeedsStocked, StockManager.instance.currentItemThatNeedsStocked.maxShelfCapacity * 2);
    }

    public override void ResetNode()
    {
        base.ResetNode();
        running = false;
    }


}
