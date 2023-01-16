using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Decision tree version of BT vending machine script - only difference is setting running to false rather than states.
public class VendingMachineLeafNode : Node
{
    public Transform vendingMachine;

    public Transform leavingPoint;

    NavMeshAgent agent;

    Customer customer;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        customer = this.GetComponent<Customer>();
    }

    protected override void Run()
    {
        
        StartCoroutine(GoToMachine());
    }

    IEnumerator GoToMachine()
    {
        agent.SetDestination(vendingMachine.position);
        yield return new WaitForSeconds(5);
        customer.boughtFromVendingMachine = true;
        agent.SetDestination(leavingPoint.position);
        yield return new WaitForSeconds(5);
        ShopStats.instance.LeaveShop(customer);
        gameObject.SetActive(false);

    }
}
