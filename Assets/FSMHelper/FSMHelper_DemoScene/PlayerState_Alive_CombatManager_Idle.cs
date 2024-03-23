using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FSMHelper;

public class PlayerState_Alive_CombatManager_Idle : BaseFSMState
{
    Animator m_Animator;
    public override void Enter()
    {
        PlayerBehaviorStateMachine SM = (PlayerBehaviorStateMachine)GetStateMachine();
        m_Animator = SM.m_GameObject.GetComponent<Animator>();
        m_Animator.SetBool("Crouch", false);
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            DoTransition(typeof(PlayerState_Alive_CombatManager_UnderAttack));
        }
    }
}