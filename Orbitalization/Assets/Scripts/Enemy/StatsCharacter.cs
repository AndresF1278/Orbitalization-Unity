using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "Character Stats", menuName = "SO/ Character Stats")]
public class StatsCharacter : ScriptableObject
{
     public string nameEnemy;
     public int damage;
     public int health;
     public float speed;
     public int XP;


}
