using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootEnemy : MonoBehaviour
{
    private LootableObject Ib;
    // Start is called before the first frame update
    void Start()
    {
        Ib = GetComponent<LootableObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Ib.RealizarLoot();
            Destroy(gameObject);

        }
    }
}
