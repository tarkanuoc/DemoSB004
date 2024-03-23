using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FSMHelper;

public class PlayerState_Alive_AnimationManager_Jump : BaseFSMState
{
    Animator m_Animator;
    float m_UpSpeed = 1.0f;

    // this is the default entry point if a transition was called to this state without any parameters
    public PlayerState_Alive_AnimationManager_Jump()
    {

    }

    // here we setup a custom entry point into the state. If the transition was called with a float parameter, this constructor would get called.
    public PlayerState_Alive_AnimationManager_Jump(float jumpSpeed)
    {
        m_UpSpeed = jumpSpeed;
    }

    public override void Enter()
    {
        PlayerBehaviorStateMachine SM = (PlayerBehaviorStateMachine)GetStateMachine();
        m_Animator = SM.m_GameObject.GetComponent<Animator>();
        
        m_Animator.SetBool("OnGround", false);
        m_Animator.SetFloat("Jump", m_UpSpeed);
        m_Animator.SetFloat("Turn", 0.0f, 0.1f, Time.deltaTime);
        m_Animator.applyRootMotion = true;
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        float distanceMoved = m_UpSpeed * Time.deltaTime;
        m_Animator.gameObject.transform.position += new Vector3(0.0f, distanceMoved, 0.0f);

        m_UpSpeed -= 9.1f * Time.deltaTime;
        m_Animator.SetFloat("Jump", m_UpSpeed);
        m_Animator.SetFloat("Forward", 0.0f, 0.1f, Time.deltaTime);

        if (m_Animator.gameObject.transform.position.y < 0.0f)
        {
            m_Animator.gameObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            DoTransition(typeof(PlayerState_Alive_AnimationManager_Idle));
        }
    }
}