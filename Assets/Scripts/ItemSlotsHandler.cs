using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemSlotsHandler : MonoBehaviour
{
    //Este script controla los dos slots de items que pueden ser utilizados durante el juego.
    //Aclaro que no son los del inventario, ya que esos luego se conectarán a estos.

    public ActiveSkillItems[] activeSkillItems = new ActiveSkillItems[2];
    private StarterAssets.StarterAssetsInputs input;
    private float item1Cooldown = 0, item2Cooldown = 0;

    void Start()
    {
        input = GetComponentInChildren<StarterAssets.StarterAssetsInputs>();
        item1Cooldown = 0; item2Cooldown = 0;
    }
    void Update()
    {
        if (input.ItemSlot_1 && item1Cooldown <= 0)
        {
            Debug.Log("Slot 1 Item Activated");
            activeSkillItems[0].Activate();
            input.ItemSlot_1 = false;
            item1Cooldown = activeSkillItems[0].Cooldown;
        }
        else { input.ItemSlot_1 = false; }
        if (input.ItemSlot_2 && item2Cooldown <= 0)
        {
            Debug.Log("Slot 2 Item Activated");
            activeSkillItems[1].Activate();
            input.ItemSlot_2 = false;
            item2Cooldown = activeSkillItems[1].Cooldown;
        }
        else { input.ItemSlot_2 = false; }

        item1Cooldown -= Time.deltaTime;
        item1Cooldown = Mathf.Clamp(item1Cooldown, 0, item1Cooldown);
        item2Cooldown -= Time.deltaTime;
        item2Cooldown = Mathf.Clamp(item2Cooldown, 0, item2Cooldown);

    }
}
