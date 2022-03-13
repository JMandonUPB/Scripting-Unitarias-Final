using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableObject : MonoBehaviour
{
    [SerializeField]
    private Transform spawPoint;
    [SerializeField]
    private int  Additional_Factor =1 ;
    [SerializeField]
    private int QuantityItem = 1;
    [SerializeField]
    [Range(0,100)]
    private int DropChance;

    private void Start()
    {
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
