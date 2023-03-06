using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float maxhealth;
    private Enemy stats;
    private PlanetController statsPlayer;
    [SerializeField] float passiveHealing; 

    private void Start()
    {
        statsPlayer = GetComponent<PlanetController>();
        stats = GetComponent<Enemy>();
         if(this.gameObject.name == "Planet")
        {
            maxhealth = statsPlayer.statsPlayer.health;
        }
        else
        {
            maxhealth = stats.StatEnemy.health;
        }
        health = maxhealth;

        UIManager.Instance.ShowHealth(health, maxhealth);
       
    }


    public void SetDamage(int damage)
    {
        if(health > health-damage)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }

        if(this.gameObject.name == "Planet")
        {
            UIManager.Instance.ShowHealth(health, maxhealth);
            if(health<= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    void CureHealth(int healing)
    {
        if(maxhealth <= health + healing)
        {
            health = maxhealth ;
        }
        else
        {
            health += healing;
        }
    }

    void MoreMaxHealth(int moreMaxHealth)
    {
        maxhealth += moreMaxHealth;
    }
}
