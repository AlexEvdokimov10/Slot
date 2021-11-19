using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : GameItem
{
    
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
        gameObject.transform.Find("itemWin").gameObject.SetActive(true);
    }
    public void FrameOf()
    {
        gameObject.transform.Find("itemWin").gameObject.SetActive(false);
    }

    
    
}
