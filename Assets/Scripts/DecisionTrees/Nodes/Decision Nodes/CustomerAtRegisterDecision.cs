using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAtRegisterDecision : DecisionNode
{


    protected override Node SelectChildNode()
    {
        if(ShopStats.instance.customerAtRegister)
        {
            return childNodes[0];
        }
        else
        {
            return childNodes[1];
        }
    }

}
