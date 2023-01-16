using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ServeCustomerLeafNode : Node
{

   

    NavMeshAgent agent;

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
        ShopStats.instance.currentTaskText.text = "Serving Customer";
        ShopStats.instance.earnings += ShopStats.instance.customerAtFront.ShoppingList.item.price;
        yield return new WaitForSeconds(3);
        ShopStats.instance.customerAtFront.served = true;
        ShopStats.instance.customerAtFront.GetComponent<BuyLeafNode>().Served();
        running = false;
        RootNode.instance.tree.setRunning(false);
    }

}
