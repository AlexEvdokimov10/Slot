using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField]
    List<Item> items;
    
    public List<Item> GetItems()
    {
        return items;
    }
    
    
}
