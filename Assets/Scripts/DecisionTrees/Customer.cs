using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This class stores important information on the customer
public class Customer : MonoBehaviour
{

    public NavMeshAgent agent;
    
    public StockManager.StockItem ShoppingList;
    [HideInInspector]
    public bool boughtFromVendingMachine;
   [HideInInspector]
    public bool needToilet = false;    
   
    public bool buyingSomething = false;

    public bool returningSomething = false;

    public bool hasID = false;

    public bool served = false;

    public bool inQueue = false;
    //HAve they picked item from shelf
    public bool gotItemFromShelf = false;

    public StockManager.StockItem itemToRefund;

   public bool ableToGoToToilet = false;

    public int age = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (ShoppingList.item == null && StockManager.instance != null)
        {
            ShoppingList = StockManager.instance.randomStockItem();
        }
    }
    //This function will decide what the customer needs from the shop.
    public void Init()
    {
        int chance = Random.Range(0, 100);
        //Chance of buying
        if(chance <=60)
        {
            AssignBuyingVariables();
            chance = Random.Range(0, 100);
            //Chance of needing the toilet and buying
            if(chance <= 20)
            {
                needToilet = true;
            }
            //Chance of toilet
        }else if(chance > 60 && chance <= 95)
        {
            //chance of needing toilet
            needToilet = true;
            chance = Random.Range(0, 100);
            
            if (chance <= 40)
            {
                AssignBuyingVariables(); // chance of also wanting to buy something
            }
        }
        else
        {
            //Chance of refunding something
            returningSomething = true;
            itemToRefund = StockManager.instance.randomStockItem();
            chance = Random.Range(0, 100);
            if (chance <= 20)
            {
                needToilet = true;
            }
        }
        
    }
    //This function assigns the variables required to buy things
    void AssignBuyingVariables()
    {
        //They are buying something
        buyingSomething = true;
        //Random item to buy
        ShoppingList = StockManager.instance.randomStockItem();
        int chance = Random.Range(12, 90);
        age = chance;
        if (age >= 18)
        {
            chance = Random.Range(0, 100);
            if(chance <=80) //80% chance of having ID when over 18
            {
                hasID = true;
            }
            else
            {
                hasID = false;
            }
        }
    }
   

    public void Leave()
    {
        
    }

}
