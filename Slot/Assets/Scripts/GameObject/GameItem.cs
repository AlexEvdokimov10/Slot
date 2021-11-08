using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> items = new List<GameObject>();
    
    public List<GameObject> GetItems()
    {
        List<GameObject> tempItems = new List<GameObject>();
        foreach(var tempItem in items)
        {
            tempItems.Add(tempItem);
        }
        return tempItems;
    }
    
}
