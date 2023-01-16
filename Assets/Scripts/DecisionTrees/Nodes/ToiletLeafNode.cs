using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToiletLeafNode : Node
{

    NavMeshAgent agent;

    public Transform toilet;

    bool ran = false;

    float distance;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(running)
        {
            distance = Vector3.Distance(transform.position, toilet.position);
            if(distance <= 5 && !ran)
            {
                ran = true;
                StartCoroutine(GoToTheToilet());
            }
        }
    }

    protected override void Run()
    {
        running = true;
        agent.SetDestination(toilet.position);
    }

    IEnumerator GoToTheToilet()
    {
        ShopStats.instance.currentTaskText.text = "In Toilet";
        yield return new WaitForSeconds(10);
        this.GetComponent<ShopWorker>().needsToilet = false;
        running = false;
        ran = false;
        RootNode.instance.tree.setRunning(false);
    }
}
