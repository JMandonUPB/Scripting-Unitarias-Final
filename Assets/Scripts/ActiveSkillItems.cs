using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillItems : MonoBehaviour
{
    public string Name, Description, Tier;
    public float StatValue, Cooldown = 5f, Duration = 120f; // Seconds
    public int Uses = 0;
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.Find("PlayerMain").GetComponent<PlayerStats>();
    }

    public void Activate()
    {
        if (Uses > 0)
        {
            if (Name == "HealthPotion") { HealthPotion(); }
            if (Name == "ResistancePotion") { ResistancePotion(); }
            Uses -= 1;
        }
        else { Debug.Log("No more uses remaining"); }
        
    }

    private void HealthPotion()
    {
        Debug.Log("Health Potion Activated");
        playerStats.Heal((int)StatValue);
    }

    private void ResistancePotion()
    {
        Debug.Log("Resistance Potion Activated");
        StartCoroutine(playerStats.AddResistances(StatValue, Duration));
        
    }
}
