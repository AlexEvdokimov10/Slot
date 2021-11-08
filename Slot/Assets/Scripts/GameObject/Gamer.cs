
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gamer : MonoBehaviour
{
    [SerializeField]
    private int priceGamer;

    [SerializeField]
    private TextMeshProUGUI textMeshPrice;
    
    private int spins;

    
    void Start()
    {
        spins = 0;
        
    }

    void Update()
    {
        TakePrice();
    }
    void TakePrice()
    {
        textMeshPrice.text = priceGamer.ToString();
    }
    
    public int GetPriceGamer()
    {
        return priceGamer;
    }
    public void SetPriceGamer(int _price)
    {
        this.priceGamer = _price;
    }
}
