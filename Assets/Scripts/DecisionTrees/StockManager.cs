using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class will handle all things stockwise.
public class StockManager : MonoBehaviour
{

    [System.Serializable]
    //Struct to store details about the stock item.
    public struct StockItem
    {
        public Stock item;
        //How many are on the shop floor
        public int amountOnShelf;
        //How much is a full shelf?
        public int maxShelfCapacity;
        //How many are in the stock room
        public int amountInStockRoom;
        //Have any been ordered?
        public bool ordered;
        public Transform pointToMoveTo;

        public Text itemNameText;
        public Text stockOnShelfText;
        public Text stockInStockRoomText;
        public Text orderedText;
    }
    // A global instance of the stockmanager
    public static StockManager instance;
    //An array to store the stock.
    public StockItem[] shopStock;

    public Text timerText;
    public bool counting = true;
    public float timer = 0;
   //Current item that needs to be stocked up
    public StockItem currentItemThatNeedsStocked;

    void Start()
    {
        instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        displayUI();
        if (counting)
        {
            timer += Time.deltaTime;
        }
        
    }
    //Displaying the UI above the shelves
    void displayUI()
    {
        foreach(StockItem item in shopStock)
        {
            item.itemNameText.text = item.item.name;
            item.stockOnShelfText.text = string.Format("Stock On Shelf: {0}/{1}", item.amountOnShelf, item.maxShelfCapacity);
            item.stockInStockRoomText.text = string.Format("Stock In Stock Room: {0}", item.amountInStockRoom);
            item.orderedText.text = item.ordered ? string.Format("Ordered?: Yes") : string.Format("Ordered?: No");
        }
        timerText.text = timer.ToString();
    }

    public bool shelfNeedingStocked()
    {
        for(int i = 0; i < shopStock.Length;i++)
        {
            if(!isShelfFull(i))
            {
                //Return the stock that needs filling
                currentItemThatNeedsStocked  = shopStock[i];
                return true;
            }
        }
        return false;
    }

    public bool debugShelfNeedingStocked()
    {
        for (int i = 0; i < shopStock.Length; i++)
        {
            if (!isShelfFull(i))
            {
                //Return the stock that needs filling
                //currentItemThatNeedsStocked = shopStock[i];
                return true;
            }
        }
        return false;
    }

    public void addToShelf(int itemIndex, int amountToRemove)
    {
        shopStock[itemIndex].amountOnShelf += amountToRemove;
    }

    public void addToStockRoom(int itemIndex, int amountToRemove)
    {
        shopStock[itemIndex].amountInStockRoom += amountToRemove;
    }

    public void removeFromShelf(int itemIndex, int amountToRemove)
    {
        shopStock[itemIndex].amountOnShelf -= amountToRemove;
    }

    public void removeFromStockRoom(int itemIndex, int amountToRemove)
    {
        shopStock[itemIndex].amountInStockRoom -= amountToRemove;
    }

    public int howManyUntilFullShelf(int itemIndex)
    {
        return shopStock[itemIndex].maxShelfCapacity - shopStock[itemIndex].amountOnShelf;
    }

    public bool isShelfFull(int itemIndex)
    {
        if(shopStock[itemIndex].amountOnShelf == shopStock[itemIndex].maxShelfCapacity)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ItemInStockRoom()
    {
        //Is there stock in the store room?
        if(currentItemThatNeedsStocked.amountInStockRoom > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool customerIsThereStock(int indexToCheck)
    {
        if(shopStock[indexToCheck].amountOnShelf > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public StockItem randomStockItem()
    {
    
        return shopStock[Random.Range(0, shopStock.Length)];    
    }
}
