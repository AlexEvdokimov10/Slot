using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    List<Item> items;
    List<Item> itemsGenereted = new List<Item>();



    public List<Item> Items { get => items; set => items = value; }
    public List<Item> ItemsGenereted { get => itemsGenereted; set => itemsGenereted = value; }

    public List<Item> GetItems()
    {
        return items;
    }
   
    public void TakeRandomElements()
    {
        for (int i = 0; i < 6; i++)
        {
            itemsGenereted.Add(items[UnityEngine.Random.Range(i, items.Count)]);
        }
    }
}
