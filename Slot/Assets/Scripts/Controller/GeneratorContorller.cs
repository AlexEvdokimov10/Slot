using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorContorller : MonoBehaviour
{
    [SerializeField]
    Slot slot;
    List<Slot> generetedReels = new List<Slot>();

    public List<Slot> GeneretedReels { get => generetedReels; set => generetedReels = value; }

    public void GenereteItems()
    {
        for (int i = 0; i < generetedReels.Count; i++)
        {

            
            for (int j = 0; j <generetedReels[i].Blocks.Count; j++)

            {
                float tempY = 0;
                generetedReels[i].Blocks[j].TakeRandomElements();
                for (int k = 0; k < generetedReels[i].Blocks[j].ItemsGenereted.Count; k++)
                {   
                    var tempObj = Instantiate<Item>(generetedReels[i].Blocks[j].ItemsGenereted[k], new Vector3(generetedReels[i].Blocks[j].Items[k].transform.position.x, generetedReels[i].Blocks[j].ItemsGenereted[k].transform.position.y, generetedReels[i].Blocks[j].ItemsGenereted[k].transform.position.z), generetedReels[i].Blocks[j].ItemsGenereted[k].GameObject.transform.rotation, generetedReels[i].Blocks[j].transform);
                    tempObj.GameObject.transform.localPosition = new Vector3(generetedReels[i].transform.position.x, tempY);
                    generetedReels[i].Blocks[j].ItemsGenereted[k] = tempObj;
                    tempY -= 50f;
                }
            }
        }
                    
    }

        
        
    

    public void GenereteReels()
    {
        
        for(int i=0;i<5;i++)
        {
           generetedReels.Add(Instantiate<Slot>(slot,new Vector3(gameObject.transform.position.x+i,slot.gameObject.transform.position.y+0.25f,gameObject.transform.position.z),slot.gameObject.transform.rotation,gameObject.transform.parent));       
        }
    }
    
    public List<Slot> GetReels()
    {
        return generetedReels;
    }

}
