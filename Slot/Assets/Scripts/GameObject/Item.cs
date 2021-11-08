using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Diamond=0,
    Crown=1,
    Melon=2,
    Bar=3,
    Seven=4,
    Cherry=5,
    Lemon=6
}
public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemType type;
    [SerializeField]
    private int itemPrice;

    public ItemType GetItemType()
    {
        return type;
    }
    public int GetPrice()
    {
        return itemPrice;
    }
    public void FrameOn()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void FramOf()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    
}
