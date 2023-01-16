using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles data about the delivery
public class DeliveryDrop : MonoBehaviour
{

    public struct Delivery
    {
        //What item is in it
        public StockManager.StockItem deliveryItem;
        //How many
        public int amount;
    }

    public static DeliveryDrop instance;

    public bool ordered = false;

    public GameObject deliveryBox;

    public Delivery currentDelivery;


    int[] contents;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        deliveryBox.SetActive(false);
    }

   public void orderDelivery(StockManager.StockItem itemToOrder,int amount)
    {
        currentDelivery.deliveryItem = itemToOrder;
        currentDelivery.amount = amount;
        ordered = true;
        StartCoroutine(Order());
    }

    IEnumerator Order()
    {
        //delivery appears after 5 seconds
        yield return new WaitForSeconds(5);
        deliveryBox.SetActive(true);
        ShopStats.instance.deliveryHere = true;

    }

    public void collectDelivery()
    {
        deliveryBox.SetActive(false);
        ordered = false;
        ShopStats.instance.deliveryHere = false;
    }
}
