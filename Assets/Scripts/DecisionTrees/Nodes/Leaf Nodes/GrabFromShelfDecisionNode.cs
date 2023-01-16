using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Decision tree version of BT shelf script - only difference is setting running to false rather than states.
public class GrabFromShelfDecisionNode : Node
{
    Customer customer;
    NavMeshAgent agent;
    bool ran = false;

    float distance = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        customer = this.GetComponent<Customer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            distance = Vector3.Distance(transform.position, agent.destination);
            if (distance <= 3 && !ran)
            {
                ran = true;
                StartCoroutine(GrabFromShelf());
            }
        }
    }

    protected override void Run()
    {
        
            agent.SetDestination(customer.ShoppingList.pointToMoveTo.position);
        
    }

    IEnumerator GrabFromShelf()
    {
        yield return new WaitForSeconds(5);
        StockManager.instance.removeFromShelf(customer.ShoppingList.item.itemIndex, 1);
        this.GetComponent<Customer>().gotItemFromShelf = true;
        Debug.Log("Grabbed From Shelf");
        running = false;
        ran = false;
        this.GetComponent<CustomerRootNode>().tree.setRunning(false);
    }
}
