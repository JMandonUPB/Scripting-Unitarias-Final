using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    float damageTimer = 0;
    float damageTimerMax = 0.3f;
    [SerializeField] int damageAmmount = -10;

    void Update()
    {
        HurtPlayerTimer();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (damageTimer > damageTimerMax)
            {
                other.GetComponent<PlayerStats>().Heal(damageAmmount);
                Debug.Log($"Damaged player for {damageAmmount} points!");
                damageTimer = 0;
            }
        }
    }

    void HurtPlayerTimer() //so enemy cant spam damage.
    {
        damageTimer += Time.deltaTime;
    }


}
