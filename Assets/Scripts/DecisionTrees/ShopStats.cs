using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


//This class keeps track of important shop statistics
public class ShopStats : MonoBehaviour
{


    public static ShopStats instance; //One overall instance
    [HideInInspector]
    public  bool customerAtRegister = false;
    [HideInInspector]
    public  bool deliveryHere = false;
    [HideInInspector]
    public  int earnings = 0;
    [HideInInspector]
    public bool dirtyFloor = false;
    public Text currentTaskText;
    public int maxCustomers = 5;
    [HideInInspector]
    public int currentCustomers = 0;
    [HideInInspector]
    public Customer customerAtFront;
    [HideInInspector]
    public Customer[] customerQueue;

    public Text dirtyFloorText;
    public Text NumOfCustomersText;
    public Text CustomerActionText;
    public Text CustomerAgeText;
    public Text IDText;

    public int totalCustomers;
    public GameObject customerToSpawn;

    private int unhappyCustomers = 0;
    private int happyCustomers = 0;
    [HideInInspector]
    public Customer[] allCustomers;
    public Transform spawnPoint;
    bool spawnedPlayer = false;
    //Tine before dirty floor chance
    int dirtyFloorInterval = 10;
    float timer = 0;
    
    public int UnhappyCustomers
    {
        get
        {
            return unhappyCustomers;
        }
        set
        {
            unhappyCustomers = value;
        }
    }

    public int HappyCustomers
    {
        get
        {
            return happyCustomers;
        }
        set
        {
            happyCustomers = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Display the UI
        displayUI();
        if(currentCustomers > 0)
        {
            customerAtRegister = true; //Customer is at front of register
            customerAtFront = customerQueue[0];
        }
        else
        {
            customerAtRegister = false;
        }
       
        if(!dirtyFloor) //If there's no dirty floor
        {
            timer += Time.deltaTime; //Add to timer
            if(timer >= dirtyFloorInterval)
            {
                timer = 0;
                spawnedPlayer = false;//Random chance of dirty floor
                int chance = Random.Range(0, 100);
                if(chance <= 5f)
                {
                    dirtyFloor = true;
                }
                chance = Random.Range(0, 100);
                if(chance <= 10f)
                {
                    FindObjectOfType<ShopWorker>().needsToilet = true;
                }
            }
            if (timer >= 3 && !spawnedPlayer)
            {
                if (totalCustomers < maxCustomers)
                {
                    int chance = Random.Range(0, 100);

                    if (chance <= 60)//High chance of spawning customer
                    {
                        spawnedPlayer = true;
                        spawnCustomer();
                    }
                }
            }
        }
        if(currentCustomers > 0)
        {
            if(customerQueue[0] == null)
            {
                LeaveQueue();
            }
        }

    }
    //UI above the counter
    void displayUI()
    {
        NumOfCustomersText.text = string.Format("Customers In Queue: {0}",currentCustomers);
        if (customerAtFront != null)
        {
            if (customerAtFront.needToilet)
            {
                CustomerActionText.text = "Current Customer Action: Asking For Toilet";
            }
            else if (customerAtFront.buyingSomething)
            {
                CustomerActionText.text = string.Format("Current Customer Action: Buying {0}", customerAtFront.ShoppingList.item.name);
            }
            else
            {
                CustomerActionText.text = string.Format("Current Customer Action: Returning {0}", customerAtFront.itemToRefund.item.name);
            }
            CustomerAgeText.text = string.Format("Current Customer Age: {0}", customerAtFront.age.ToString());
            IDText.text = string.Format("ID?: {0}", customerAtFront.hasID ? "Yes" : "No");
        }
        else
        {
            CustomerActionText.text = "Current Customer Action: ";
            CustomerAgeText.text = "Current Customer Age: ";
            IDText.text = "ID?: ";
        }
        if (dirtyFloor)
        {
            dirtyFloorText.text = "Dirty Floor";
        }
        else
        {
            dirtyFloorText.text = "";
        }
    }

    void spawnCustomer()
    {
        //Spawn a customer
        for (int i = 0; i < customerQueue.Length; i++)
        {
            if (allCustomers[i] == null)
            {
                GameObject cust = Instantiate(customerToSpawn, spawnPoint); //Spawn the Gameobject
                cust.SetActive(true); //Set them active
                allCustomers[i] = cust.GetComponent<Customer>();
                allCustomers[i].Init();
                totalCustomers++;
                break;
            }
        }

    }
    //Despawn a customer
    public void LeaveShop(Customer customerToLeave)
    {
        for (int i = 0; i < allCustomers.Length; i++)
        {
            if (allCustomers[i] == customerToLeave)
            {
                allCustomers[i] = null;
                Destroy(customerToLeave.gameObject);
                totalCustomers--;
                break;
            }
        }
    }

    //Join the customer queue
   public void JoinQueue(Customer joiningCustomer)
    {
       // Debug.Log("Joining Queue");
        for(int i = 0; i < customerQueue.Length;i++)
        {
            if(customerQueue[i] == null)
            {
                customerQueue[i] = joiningCustomer;
                joiningCustomer.inQueue = true;
                currentCustomers++;
                break;
            }
        }
        
    }

    //Leave the customer queue
   public void LeaveQueue()
    {
        //Debug.Log("LEaving Queue");
        for(int i = 0; i < customerQueue.Length - 1; i++)
        {
            customerAtFront.inQueue = false;
            customerQueue[i] = customerQueue[i + 1]; //Move along the rest of the queue
        }
        customerQueue[customerQueue.Length - 1] = null;
        if (currentCustomers - 1 >= 0)
        {
            currentCustomers--;
        }
    }
}
