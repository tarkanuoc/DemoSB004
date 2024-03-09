using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : Health
{
    protected override void Die()
    {
        base.Die();
        MissionManager.Instance.OnZombieKilled();
    }
}
