using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unitys scriptable object system allows for data driven classes with no functions. These can be created via the editor
[CreateAssetMenu(fileName = "New Stock Item",menuName = "Stock")]
public class Stock : ScriptableObject
{

    public new string name;

    public Sprite icon;

    public int itemIndex;

    public int startingStock;

    public int price;

    public bool ageRestricted;
    

}
