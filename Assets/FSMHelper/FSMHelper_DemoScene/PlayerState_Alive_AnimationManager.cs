using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FSMHelper;

public class PlayerState_Alive_AnimationManager : BaseFSMState
{
    public override void SetupDefinition(ref FSMStateType stateType, ref List<System.Type> children)
    {
        // three children states
        stateType = FSMStateType.Type_OR;
        children.Add(typeof(PlayerState_Alive_AnimationManager_Idle));
        children.Add(typeof(PlayerState_Alive_AnimationManager_Walk));
        children.Add(typeof(PlayerState_Alive_AnimationManager_Jump));
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        // example of broadcasting a message to the whole statemachine
        // We do this because the Die state is not at the same level as this state, so a broadcast is more convenient than getting the parent's parent's parent
        if (Input.GetButtonDown("Fire3"))
        {
            object[] args = new object[1];
            args[0] = "Die";
            BroadcastMessage(args);
        }
    }
}