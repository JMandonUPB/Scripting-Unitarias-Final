using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int maxHealth = 100, currentHealth = 30;
    public float LightningRES = 0, FireRES = 0, IceRES = 0, PhysicalRES = 0;

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public IEnumerator AddResistances(float value, float duration)
    {
        LightningRES += value;
        FireRES += value;
        IceRES += value;
        PhysicalRES += value;
        yield return new WaitForSeconds(duration);
        LightningRES -= value;
        FireRES -= value;
        IceRES -= value;
        PhysicalRES -= value;
        Debug.Log("Resistances Restored");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HealingPickup")
        {
            Heal(other.gameObject.GetComponent<HealthPickup>().AmountToHeal);
            Destroy(other.gameObject);
            Debug.Log("Current Health: " + currentHealth + "/" + maxHealth);
        }
    }
}
