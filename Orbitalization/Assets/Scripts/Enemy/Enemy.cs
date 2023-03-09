using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public StatsCharacter StatEnemy;
    private GameObject Player;

    private void Update()
    {
        Player = GameObject.Find("Planet");
        
    }
}
