using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinations : MonoBehaviour
{

    int[,] combinationsItem = new int[30, 5] {
        { 2,2,2,2,2 },
        {2,3,3,3,2 },
        {2,2,2,2,3},
        {2,2,2,3,2 },
        {2,2,3,2,2},
        {2,3,2,2,2 },
        {2,2,2,2,4 },
        {2,2,2,4,2 },
        {2,2,4,2,2 },
        {2,4,2,2,2 },
        {2,4,4,4,4 },
        {2,2,4,4,4 },
        {2,2,4,4,4 },
        {2,2,3,3,3 },
        {2,2,4,3,3 },
        {2,3,3,3,3 },
        {3,3,3,3,4 },
        {3,3,2,2,2 },
        {3,3,3,3,2 },
        {3,3,3,2,2 },
    {3,2,2,2,2 },
    {3,3,3,3,3 },
    {3,3,3,4,4 },
    {3,4,4,4,4 },
    {4,4,4,4,4 },
    {4,2,2,2,2 },
    {4,4,2,2,2},
    {4,4,4,2,2 },
    {4,4,4,4,3 },
    {4,4,4,3,3 } };
   
    
    public int GetCombinations(int indexLine,int indexCell)
    {
        return combinationsItem[indexLine,indexCell];
    }

} 
