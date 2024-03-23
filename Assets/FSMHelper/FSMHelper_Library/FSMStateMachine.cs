using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FSMHelper
{
    /// <summary>
    /// The state machine
    /// You can instantiate this directly, or you can make a class inheriting this.
    /// </summary>
    public class FSMStateMachine
    {
        private FSMStateMachineLogic m_Logic = null;

        /// <summary>
        /// Constructor for the state machine.
        /// </summary>
        public FSMStateMachine()
        {
            
        }

        /// <summary>
        /// Sets up the first layer of the state machine. Determines if it has children, and if the state is an OR vs AND state.
        /// </summary>
        /// <param name="stateType"> States of type OR means that only one of its children is active at any one time. Type AND means all its children states are active</param>
        /// <param name="children"> The list of child states for this state. If the state type is OR, the first child in this list will be the initial active state. </param>
        public virtual void SetupDefinition(ref FSMStateType stateType, ref List<System.Type> children)
        {

        }

        /// <summary>
        /// Calling this will enter the state machine's initial state(s)
        /// </summary>
        public virtual void StartSM()
        {
            FSMStateType stateType = FSMStateType.Type_OR;
            List<System.Type> children = new List<System.Type>();
            SetupDefinition(ref stateType, ref children);

            m_Logic = new FSMStateMachineLogic(stateType, children, this, null);
            m_Logic.Enter(null);
        }

        /// <summary>
        /// Calling this will trigger Update() on all active states in the state machine
        /// </summary>
        public virtual void UpdateSM()
        {
            if (m_Logic != null)
            {
                m_Logic.Update();
            }
        }

        /// <summary>
        /// Calling this will trigger Exit() on all active states in the state machine.
        /// </summary>
        public virtual void StopSM()
        {
            if (m_Logic != null)
            {
                m_Logic.Exit();
                m_Logic = null;
            }
        }

        /// <summary>
        /// Broadcasts the specified arguments to all active states in the state machine.
        /// </summary>
        /// <param name="args"> The arguments to send in the broadcast </param>
        public void BroadcastMessage(object[] args)
        {
            m_Logic.ReceiveMessage(args);
        }

        /// <summary>
        /// Checks if the statemachine has an active state of the specified class
        /// </summary>
        /// <param name="state"> The state to check for. </param>
        /// <returns> Returns if the specified state is active in the statemachine or not.</returns>
        public bool IsInState(System.Type state)
        {
            return m_Logic.IsInState(state);
        }

        /// <summary>
        /// Prints to the debug log, a tree of all the currently active states
        /// </summary>
        public void PrintActiveStateTree()
        {
            string result = this.ToString();
            result += "\n";
            result += m_Logic.GetActiveStateTreeText(0);
            Debug.Log(result);
        }
    }
}
