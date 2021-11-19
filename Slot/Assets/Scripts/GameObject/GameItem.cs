using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Diamond = 0,
    Crown = 1,
    Melon = 2,
    Bar = 3,
    Seven = 4,
    Cherry = 5,
    Lemon = 6
}

public class GameItem : MonoBehaviour
{
    public GameObject gameObject;
    [SerializeField]
    protected ItemType type;
    [SerializeField]
    protected int itemPrice;

    public GameObject GameObject { get => gameObject; set => gameObject = value; }
}
