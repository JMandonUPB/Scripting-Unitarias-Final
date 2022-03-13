using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootChest : MonoBehaviour
{
    [SerializeField]
    private Transform spawPoint;
    [SerializeField]
    private int Additional_Factor = 1;//probabilidad mayor 
    [SerializeField]
    private int QuantityItem = 1; // cantidad
    [SerializeField]
    [Range(0, 100)]
    private int DropChance;
   

    private void Start()
    {

        QuantityItem = Random.Range(0,5);
        if (spawPoint == null)
        {
            spawPoint = transform;
        }
    }
    public void RealizarLoot()
    {
        LootSystem.Intance.SpwanLoot(spawPoint, Additional_Factor, QuantityItem, DropChance);
    }
}
