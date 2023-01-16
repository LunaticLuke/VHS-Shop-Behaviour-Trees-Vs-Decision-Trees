using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Handles buying something with decision tree
public class BuyLeafNode : Node
{
    Customer customer;
    NavMeshAgent agent;
    public Transform customerQueue;
    public Transform leavingPoint;
    [HideInInspector]
    public bool served = false;
    
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        customer = this.GetComponent<Customer>();
    }

    protected override void Run()
    {
       
    }

    public void Served()
    {
        Debug.Log("Served");
        customer.inQueue = false;
        if (!customer.returningSomething)
        ShopStats.instance.LeaveQueue();
        customer.buyingSomething = false;
        ShopStats.instance.HappyCustomers += 1;
        running = false;
        //reset the root node
        this.GetComponent<CustomerRootNode>().tree.setRunning(false);
    }

    public void Refused()
    {
        Debug.Log("Refused");
        customer.inQueue = false;
        if (!customer.returningSomething)
        ShopStats.instance.LeaveQueue();
        customer.buyingSomething = false;
        running = false;
        this.GetComponent<CustomerRootNode>().tree.setRunning(false);
    }
}
