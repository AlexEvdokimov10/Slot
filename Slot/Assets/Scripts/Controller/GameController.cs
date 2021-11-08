using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private float timeInerval;
    public static event Action HandlePulled = delegate { };
    [SerializeField]
    private Text prizeText;
    [SerializeField]
    private TextMeshProUGUI textBet;
    [SerializeField]
    private List<Slot> slots;
    [SerializeField]
    private Item[,] items=new Item[10,5];
    [SerializeField]
    Combinations combinations=new Combinations();
    private int prize = 0;
    [SerializeField]
    private Gamer gamer;

   



    private int bet=0;
    
    public bool rowStopped;
    public string stoppedSlot;


    void Start()
    {
        rowStopped = true;
        TakeElement();
        HandlePulled +=StartRotating;
        
   
    }
    private void StartRotating()
    {
        if (rowStopped && bet>1)
        {
            StartCoroutine("RollElements");
            rowStopped = false;
          

        }
    }

   
    private void TakeElement()
    {
      
       
        for(int i = 0; i < slots.Count; i++)
        {
            int j = 0;
            foreach (var tempSlot in slots[i].GetItems())
            {
                items[j, i] = tempSlot;
                j++;
            }
        }
        
    }
    public void StartHandle()
    {
        HandlePulled();
    }
    
    private IEnumerator RollElements()
    {
        
        timeInerval = 0.001f;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < UnityEngine.Random.Range(100,103); j++)
            {
                ShiftMatrix(i);

                yield return new WaitForSeconds(timeInerval);
            }

        }
        TakePrize();
        bet = 0;
        textBet.text = "Bet: " + bet;
        prize = 0;


    }
    void ShiftMatrix(int _indexCell)
    {
        for (int i = 0; i < 5; i++)
        {
            if (i == _indexCell)
            {
                for (int j = 1; j < 10; j++)
                {
                    items[j, i].FramOf();
                    ChangePositon(i, j);
                    items[j, i].gameObject.transform.localPosition = new Vector3(items[j, i].transform.localPosition.x, items[j, i].transform.localPosition.y + 50f, items[j, i].transform.localPosition.z);
                    var tempObject = items[j - 1, i];
                    items[j - 1, i] = items[j, i];
                    items[j, i] =tempObject ;
                 
                }


            }
          
        }
    }

   
    void TakePrize()
    {
        TakeTempCombinations(); 
        rowStopped = true;
    }
    void TakeTempCombinations()
    {

        List<int> tempCombinatons = new List<int>();
        bool statusCombination = false;
        
        for(int i = 0; i < 30; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                if (!checkItem(i, j))
                {
                    prize = 0;
                    statusCombination = false;
                    break;
                }
                else
                {
                    tempCombinatons.Add(j);
                    prize +=bet*items[combinations.GetCombinations(i, j), j].GetPrice();
                    statusCombination = true;
                }
                

            }
            if (statusCombination)
            {
                PrizeControl(tempCombinatons, i);
            }

        }
       
    }

    private void PrizeControl(List<int> tempCombinatons, int i)
    {
        foreach (var tempIndexCell in tempCombinatons)
        {

            items[combinations.GetCombinations(i, tempIndexCell), tempIndexCell].FrameOn();
            items[combinations.GetCombinations(i, tempIndexCell + 1), tempIndexCell + 1].FrameOn();

        }
        prizeText.text = "Prize : " + prize ;
        gamer.SetPriceGamer(gamer.GetPriceGamer() + prize);


    }

    private bool checkItem(int _indexLine, int _indexCell)
    {
        return items[combinations.GetCombinations(_indexLine, _indexCell), _indexCell].GetItemType() == items[combinations.GetCombinations(_indexLine, _indexCell+1 ), _indexCell+1 ].GetItemType();
    }


    private void ChangePositon(int _indexCell, int _indexRow)
    {
        if (items[_indexRow, _indexCell].transform.localPosition.y >= 225f)
        {
            items[_indexRow, _indexCell].transform.localPosition = new Vector3(items[_indexRow, _indexCell].transform.localPosition.x, -225f, items[_indexRow, _indexCell].transform.localPosition.z);
        }
        
    }
    public void makeBet(int _bet)
    {
        if (gamer.GetPriceGamer()>=_bet)
        {
            bet += _bet;
            gamer.SetPriceGamer(gamer.GetPriceGamer() - _bet);
            textBet.text = "Bet: " + bet;
        }
    }

}
