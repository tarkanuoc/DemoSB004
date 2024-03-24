using FSMHelper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStateMachine : FSMStateMachine
{
    public ZombieAI ZombieAI = null;

    public ZombieStateMachine(ZombieAI ai)
    {
        ZombieAI = ai;
    }

    public override void SetupDefinition(ref FSMStateType stateType, ref List<System.Type> children)
    {
        children.Add(typeof(ZombieState_Idle));
        children.Add(typeof(ZombieState_Attack));
        children.Add(typeof(ZombieState_Trace));
        children.Add(typeof(ZombieState_ComeBack));
    }
}
