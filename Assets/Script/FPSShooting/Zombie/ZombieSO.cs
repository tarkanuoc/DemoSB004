using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieSO", menuName = "ScriptableObjects/CreateZombieSO")]
public class ZombieSO : ScriptableObject
{
    public int HP;
    public int Damage;
    public float Speed;
}