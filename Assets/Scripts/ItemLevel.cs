using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLevel : MonoBehaviour
{
   private int level = 0;



    
    public int Level { get => level; set => level = LootSystem.Intance.Level; }
}
