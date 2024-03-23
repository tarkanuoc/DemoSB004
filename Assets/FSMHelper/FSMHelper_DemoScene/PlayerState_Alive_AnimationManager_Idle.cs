using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FSMHelper;

public class PlayerState_Alive_AnimationManager_Idle : BaseFSMState
{
    Animator m_Animator;

    public override void Enter()
    {
        PlayerBehaviorStateMachine SM = (PlayerBehaviorStateMachine)GetStateMachine();
        m_Animator = SM.m_GameObject.GetComponent<Animator>();
        m_Animator.SetBool("OnGround", true);
        m_Animator.SetFloat("Jump", 0.0f);
        m_Animator.SetFloat("Turn", 0.0f, 0.1f, Time.deltaTime);
        m_Animator.applyRootMotion = false;
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        m_Animator.SetFloat("Forward", 0.0f, 0.1f, Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            // calling a transition without any parameters
            DoTransition(typeof(PlayerState_Alive_AnimationManager_Jump));
            return;
        }

        float verticalInput = Input.GetAxis("Vertical");
        if (Mathf.Abs(verticalInput) > 0.5f)
        {
            // calling a transition without any parameters
            DoTransition(typeof(PlayerState_Alive_AnimationManager_Walk));
            return;
        }
    }
}