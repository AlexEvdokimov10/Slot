using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private float timeInerval = 0;
    private float timeRotating=0;
    public static event Action HandlePulled = delegate { };
    [SerializeField]
    private Text prizeText;
    [SerializeField]
    private TextMeshProUGUI textBet;
    [SerializeField]
    private List<Slot> slots;
    [SerializeField]
    private Item[,] items=new Item[12,5];
    [SerializeField]
    Combinations combinations=new Combinations();
    private int prize = 0;
    [SerializeField]
    private Gamer gamer;
    [SerializeField]
    GeneratorContorller generatorContorller;
    [SerializeField]
    AudioSource audioSlot;
   



    private int bet=0;
    
    public bool rowStopped;
    public string stoppedSlot;


    void Start()
    {


        generatorContorller.GenereteReels();
        generatorContorller.GenereteItems();
        slots = generatorContorller.GetReels();
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
            prizeText.text = "Prize : " + prize;

        }
    }

   
    private void TakeElement()
    {
      
       
        for(int i = 0; i < slots.Count; i++)
        {
            int k = 0;
            for (int j = 0;j<slots[i].Blocks.Count; j++)
            {
               foreach(var tempItem in slots[i].Blocks[j].ItemsGenereted)
                {
                    
                    items[k, i] = tempItem;
                    k++;
                }
            }

        }
        
    }
    public void StartHandle()
    {
        HandlePulled();
    }
    
    private IEnumerator RollElements()
    {

        audioSlot.PlayDelayed(0);
        audioSlot.loop = true;
        for (int i = 0; i < 5; i++)
        {
           
            float randomValue= UnityEngine.Random.Range(1, 12) ;

            
            timeRotating = randomValue;
            audioSlot.Play();
            while (timeRotating>0)
            {
               
                ShiftMatrix(i,randomValue);

                yield return new WaitForSeconds(timeInerval);
                timeRotating -= Time.deltaTime;
            }
            audioSlot.Stop();

        }
        TakePrize();
        bet = 0;
        textBet.text = "Bet: " + bet;
        prize = 0;


    }
    void ShiftMatrix(int _indexCell,float _randomValue)
    {
       
        for (int i = 0; i < 5; i++)
        {
            
            if (i == _indexCell)
            {
                
                    for (int j = 1; j < 12; j++)
                    {
                        items[j, i].FrameOf();

                        var tempObject = items[j - 1, i];
                        items[j - 1, i] = items[j, i];
                        items[j, i] = tempObject;
                        
                      
                    }
                for (int k = 0; k < 2; k++)
                {
                    slots[i].Blocks[k].transform.localPosition += new Vector3(0, 50f); 
                    ChangePositon(i, k);

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


    private void ChangePositon(int _indexCell,int _indexBlock)
    {
        if (slots[_indexCell].Blocks[_indexBlock].transform.localPosition.y > 350f)
        {
           slots[_indexCell].Blocks[_indexBlock].transform.localPosition = new Vector3(slots[_indexCell].Blocks[_indexBlock].transform.localPosition.x, -200f ,slots[_indexCell].Blocks[_indexBlock].transform.localPosition.z);
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
