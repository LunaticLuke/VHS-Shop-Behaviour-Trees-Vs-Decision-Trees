using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Decision tree version of BT queue script - only difference is setting running to false rather than states.
public class JoinQueue : Node
{

    public Transform counter;
    NavMeshAgent agent;
    Customer customer;
    float distance = 0;

    bool ran = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        customer = GetComponent<Customer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
           // Debug.Log("Running JoinQueue Leaf");
            distance = Vector3.Distance(transform.position, counter.position);
            //Debug.Log(distance);
            if (distance <= 1.25 && !ran)
            {
                ran = true;
                ShopStats.instance.JoinQueue(customer);
            }
            if (customer.served)
            {
                running = false;
                ran = false;
                this.GetComponent<CustomerRootNode>().tree.setRunning(false); 
            }
        }
    }

    protected override void Run()
    {
        customer.served = false;
        agent.SetDestination(counter.position);
    }
}
