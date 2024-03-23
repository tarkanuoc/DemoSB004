using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FSMHelper;

public class PlayerState_Alive : BaseFSMState
{
    public override void SetupDefinition(ref FSMStateType stateType, ref List<System.Type> children)
    {
        // here we have nested states within a state
        // This is a AND type of state, which means both the animation manager and the combat manager will be running in parallel
        stateType = FSMStateType.Type_AND;
        children.Add(typeof(PlayerState_Alive_AnimationManager));
        children.Add(typeof(PlayerState_Alive_CombatManager));
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

    public override void ReceiveMessage(object[] args)
    {
        // here we are receiving a message that was broadcasted to the whole statemachine
        if (args.Length == 1 && (string) args[0] == "Die")
        {
            // example of a transition
            DoTransition(typeof(PlayerState_Dead));
        }
    }
}