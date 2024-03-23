using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FSMHelper;

// Example of a state machine class inheriting from FSMStateMachine
public class PlayerBehaviorStateMachine : FSMStateMachine
{
    public GameObject m_GameObject = null;

    public PlayerBehaviorStateMachine(GameObject characterObj)
    {
        m_GameObject = characterObj;
    }

    // here we define the structure of the state machine's first layer
    public override void SetupDefinition(ref FSMStateType stateType, ref List<System.Type> children)
    {
        // default is an OR-type state
        // the first child added will be the inital state
        children.Add(typeof(PlayerState_Alive));
        children.Add(typeof(PlayerState_Dead));
    }
}
