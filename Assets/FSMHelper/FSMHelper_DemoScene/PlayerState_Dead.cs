using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FSMHelper;

public class PlayerState_Dead : BaseFSMState
{
    public override void Enter()
    {
        PlayerBehaviorStateMachine SM = (PlayerBehaviorStateMachine)GetStateMachine();
        SkinnedMeshRenderer[] renders = SM.m_GameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        if (renders.Length != 0)
        {
            foreach (SkinnedMeshRenderer render in renders)
            {
                render.enabled = false;
            }
        }
        
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
    }
}