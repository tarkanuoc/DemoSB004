using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FSMHelper;

public class PlayerState_Alive_CombatManager_UnderAttack : BaseFSMState
{
    public override void Enter()
    {
        GameObject.Find("Directional Light").GetComponent<Light>().enabled = false;
    }

    public override void Exit()
    {
        GameObject.Find("Directional Light").GetComponent<Light>().enabled = true;
    }

    public override void Update()
    {
        if (!Input.GetButton("Fire1"))
        {
            DoTransition(typeof(PlayerState_Alive_CombatManager_Idle));
        }
    }
}