using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FSMHelper;

public class PlayerState_Alive_CombatManager : BaseFSMState
{
    Animator m_Animator;
    public override void SetupDefinition(ref FSMStateType stateType, ref List<System.Type> children)
    {
        stateType = FSMStateType.Type_OR;
        children.Add(typeof(PlayerState_Alive_CombatManager_Idle));
        children.Add(typeof(PlayerState_Alive_CombatManager_UnderAttack));
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        
    }
}