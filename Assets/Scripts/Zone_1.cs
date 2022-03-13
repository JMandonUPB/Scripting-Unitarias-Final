using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player") )
        {
            LootSystem.Intance.Level = 1;

        }
    }
    }
