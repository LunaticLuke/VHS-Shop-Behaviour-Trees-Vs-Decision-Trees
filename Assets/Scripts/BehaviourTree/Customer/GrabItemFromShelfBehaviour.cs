using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This class handles the act of grabbing an item from the shelf 
public class GrabItemFromShelfBehaviour : BehaviourTreeNode
{
    Customer customer;
    NavMeshAgent agent;

    bool running = false;
    bool ran = false;

    float distance = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        customer = this.GetComponent<Customer>();
    }

    private void Update()
    {

        if (running)
        {
            distance = Vector3.Distance(transform.position, agent.destination);
            if (distance <= 3 && !ran)
            {
                //Within range, grab from shelf
                ran = true;
                StartCoroutine(GrabFromShelf());
            }
        }
    }
    protected override void NodeFunction()
    {
        if (!running && customer.ShoppingList.item != null)
        {
             agent.SetDestination(customer.ShoppingList.pointToMoveTo.position);
            running = true;
        }
    }

    IEnumerator GrabFromShelf ()
    {
        yield return new WaitForSeconds(5);
        StockManager.instance.removeFromShelf(customer.ShoppingList.item.itemIndex, 1);
        this.state = State.SUCCESS;
    }

    public override void ResetNode()
    {
        base.ResetNode();
        running = false;
        ran = false;
    }
}
