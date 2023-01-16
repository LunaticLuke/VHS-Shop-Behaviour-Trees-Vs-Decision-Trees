using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Decision tree version of BT toilet script - only difference is setting running to false rather than states.
public class CustomerToilet : Node
{
    public Transform toilet;

    Customer customer;

    NavMeshAgent agent;

    float distance = 0;

    bool ran = false;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        customer = this.GetComponent<Customer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            distance = Vector3.Distance(transform.position, toilet.position);
            if (distance <= 5 && !ran)
            {
                ran = true;
                StartCoroutine(GoToToilet());
            }
        }
    }

    protected override void Run()
    {
        Debug.Log("Going To The Toilet");
        customer.inQueue = false;
        ShopStats.instance.LeaveQueue();
        agent.SetDestination(toilet.position);
    }

    IEnumerator GoToToilet()
    {
        yield return new WaitForSeconds(10);
        customer.needToilet = false;
        customer.ableToGoToToilet = false;
        customer.served = false;
        running = false;
        this.GetComponent<CustomerRootNode>().tree.setRunning(false);
    }


}
