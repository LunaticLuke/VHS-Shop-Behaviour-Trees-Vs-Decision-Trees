using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The checking of a customers ID
public class IDCheck : BehaviourTreeNode
{
    protected override void NodeFunction()
    {
        Customer customerAtFront = ShopStats.instance.customerAtFront;
        //If they are less than 18 - instant refusal as this node triggers on an age restricted item.
        if (customerAtFront.age < 18)
        {
            Debug.Log("Customer Is Too Young");
            customerAtFront.served = true;
            //Call the customers refused behaviour
            customerAtFront.GetComponent<BuyBehaviourLeafNode>().Refused();
            this.state = State.FAILURE;
        } else
        {
            //If they are over 18 and have ID, serve them
            if (ShopStats.instance.customerAtFront.hasID)
            {
                Debug.Log("Customer Has ID");
                customerAtFront.served = true;
                customerAtFront.GetComponent<BuyBehaviourLeafNode>().Served();
                this.state = State.SUCCESS;
            }
            //If they are over 18 but have no ID, refuse them
            else
            {
                Debug.Log("Customer Has No ID");
                customerAtFront.served = true;
                customerAtFront.GetComponent<BuyBehaviourLeafNode>().Refused();
                this.state = State.FAILURE;
            }
        }
    }


}
