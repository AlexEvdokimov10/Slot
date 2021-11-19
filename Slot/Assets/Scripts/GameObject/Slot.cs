using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField]
    List<Block> blocks;

    public List<Block> Blocks { get => blocks; set => blocks = value; }
}
