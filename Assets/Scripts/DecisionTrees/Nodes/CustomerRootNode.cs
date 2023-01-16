using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerRootNode : MonoBehaviour
{
    public Node tree = null;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tree != null && this.GetComponent<Customer>().ShoppingList.item != null)
        {
            if (!tree.isNodeRunning())
            {
                tree.ExecuteNode();
            }
        }
    }
}
