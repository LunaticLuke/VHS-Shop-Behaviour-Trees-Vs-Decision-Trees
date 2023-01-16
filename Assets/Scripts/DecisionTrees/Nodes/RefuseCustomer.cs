using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RefuseCustomer : Node
{
    public Transform pointToMoveTo;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    protected override void Run()
    {
        StartCoroutine(refuseCustomer());
    }

    IEnumerator refuseCustomer()
    {
        ShopStats.instance.currentTaskText.text = "Refusing Customer";
        yield return new WaitForSeconds(3);
        ShopStats.instance.customerAtFront.served = true;
        ShopStats.instance.customerAtFront.GetComponent<BuyLeafNode>().Refused();
        running = false;
        RootNode.instance.tree.setRunning(false);
    }
}
