using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

//Serving a customer who is buying something
public class ServeCustomersLeaf : BehaviourTreeNode
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
            StartCoroutine(serveCustomer());
            running = true;
        }
    }

    IEnumerator serveCustomer()
    {
        ShopStats.instance.currentTaskText.text = "Serving Customer";
         ShopStats.instance.earnings += ShopStats.instance.customerAtFront.ShoppingList.item.price;
         yield return new WaitForSeconds(3);
         ShopStats.instance.customerAtFront.served = true;
        //They have been served
        ShopStats.instance.customerAtFront.GetComponent<BuyBehaviourLeafNode>().Served();

        this.state = State.SUCCESS;
    }

    public override void ResetNode()
    {
        base.ResetNode();
        running = false;
    }

}
