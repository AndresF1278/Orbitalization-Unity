using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsModStats : MonoBehaviour
{
    private StatsCharacter StatsPlayer;
    private ShotController statsShot;
    private OriginalStatsPlayer originalStats;

    [SerializeField] private float speedMovement;
    [SerializeField] private float speedBullet;
    [SerializeField] private int healthPlayer;
    [SerializeField] private float cadenceLess;

    private void Start()
    {
       
        StatsPlayer = FindObjectOfType<PlanetController>().statsPlayer;
        statsShot = FindObjectOfType<ShotController>();
    }
    public void MoreSpeedMovement()
    {
        StatsPlayer.speed += speedMovement;
        Debug.Log(StatsPlayer.speed);
        UIManager.Instance.DeactivateItemSelector();
        GameManager.instance.TogglePause();
    }

    public void MoreHealthMax()
    {
        StatsPlayer.health += healthPlayer;
        Debug.Log(StatsPlayer.health);
        UIManager.Instance.DeactivateItemSelector();
        GameManager.instance.TogglePause();
    }

    public void MoreSpeedBullets()
    {
        statsShot.preFabBullet.GetComponent<Bullet>().speed += speedBullet;
        Debug.Log(statsShot.preFabBullet.GetComponent<Bullet>().speed);
        UIManager.Instance.DeactivateItemSelector();
        GameManager.instance.TogglePause();
    }

    public void PowerCadence()
    {
        float CalculeMaxBullets = cadenceLess * 10;
        
        statsShot.maxBullets *= (int) CalculeMaxBullets;
        statsShot.cadence -= cadenceLess;
        Debug.Log(statsShot.cadence);
        UIManager.Instance.DeactivateItemSelector();
        GameManager.instance.TogglePause();
    }

}

