using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zone_2 : MonoBehaviour
{
  
    void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            LootSystem.Intance.Level = 0;
        }
    }
}
