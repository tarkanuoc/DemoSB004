using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : Health
{
    [SerializeField] private ZombieSO ZombieSO;
    protected override void Start()
    {
        base.Start();
        MaxHP = ZombieSO.HP;
    }

    protected override void Die()
    {
        base.Die();
        MissionManager.Instance.OnZombieKilled();
    }
}
