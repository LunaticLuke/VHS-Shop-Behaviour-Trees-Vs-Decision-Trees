using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootNode : MonoBehaviour
{
    public Node tree = null;

    public static RootNode instance;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (tree != null)
        {
            if (!tree.isNodeRunning())
            {
                tree.ExecuteNode();
            }
        }
    }
}
