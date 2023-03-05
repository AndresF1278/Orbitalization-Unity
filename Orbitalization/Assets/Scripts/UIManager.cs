using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public  Slider sliderExp;
    public  Slider sliderHealth;
    private float healthPlayer;
    private GameObject Player;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Player = GameObject.Find("Planet");
        healthPlayer = Player.GetComponent<PlanetController>().statsPlayer.health;

        sliderHealth.maxValue = healthPlayer;
        sliderHealth.value = healthPlayer;
        

        sliderExp.value = 0;
    }
    private void Update()
    {
        sliderExp.value = Mathf.MoveTowards(sliderExp.value, ExpManager.Instance.CurrentXP, Time.deltaTime * 5);
        
        sliderHealth.value = Mathf.MoveTowards(sliderHealth.value, healthPlayer, Time.deltaTime * 5);

        sliderHealth.transform.position = new Vector3(0, -4, 0) + Player.transform.position;



    }

    public void ShowExp( int xpForLevel)
    {
        sliderExp.maxValue = xpForLevel; 
    }
    public void FillResetXp(int currentXp)
    {
        sliderExp.value = currentXp;
    }


    public void ShowHealth(float currentHealth, float maxHealth)
    {
        sliderHealth.maxValue = maxHealth;
        healthPlayer = currentHealth;
    }
    
}
