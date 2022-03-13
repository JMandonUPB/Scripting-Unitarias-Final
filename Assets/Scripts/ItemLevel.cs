using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLevel : MonoBehaviour
{
   private int level = 0;

    private void Update()
    {

       Level= LootSystem.Intance.Level ;

    }
    public int Level { get => level; set => level = value; }
}
