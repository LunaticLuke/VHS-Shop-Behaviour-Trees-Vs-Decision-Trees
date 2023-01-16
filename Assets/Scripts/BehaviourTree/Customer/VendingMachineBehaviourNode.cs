using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

//This class handles the customer going to the vending machine
public class VendingMachineBehaviourNode : BehaviourTreeNode
{

    public Transform vendingMachine;

    public Transform leavingPoint;

    NavMeshAgent agent;

    bool running = false;

    Customer customer;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        customer = this.GetComponent<Customer>();
    }

    // Update is called once per frame
    protected override void NodeFunction()
    {
        if (!running)
        {
            StartCoroutine(GoToMachine());
            running = true;
        }
        Debug.Log("GoingToVendingMachine");
    }
    

    IEnumerator GoToMachine()
    {
        //Go there and wait
        agent.SetDestination(vendingMachine.position);
        yield return new WaitForSeconds(5);
        //Now leave
        customer.boughtFromVendingMachine = true;
        agent.SetDestination(leavingPoint.position);
        yield return new WaitForSeconds(5);
        ShopStats.instance.LeaveShop(customer);
        gameObject.SetActive(false);

    }

    public override void ResetNode()
    {
        base.ResetNode();
        running = false;

    }
}
