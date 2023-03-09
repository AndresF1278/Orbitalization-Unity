using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalStatsPlayer : MonoBehaviour
{
    private StatsCharacter StatsPlayer;
    private ShotController statsShot;
    private float speedMovePlayer;
    private float speedBulletPlayer;
    private int health;
    private float candece;
    public string hola;

    private void Start()
    {
        StatsPlayer = FindObjectOfType<PlanetController>().statsPlayer;
        statsShot = FindObjectOfType<ShotController>();

        speedMovePlayer = StatsPlayer.speed;
        health = StatsPlayer.health;
        speedBulletPlayer = statsShot.preFabBullet.GetComponent<Bullet>().speed;
        candece = statsShot.cadence;

    }

    public void ResetStats()
    {
        StatsPlayer.speed = speedMovePlayer;
        StatsPlayer.health = health;
        statsShot.preFabBullet.GetComponent<Bullet>().speed = speedBulletPlayer;
        statsShot.cadence = candece;

    }

}