using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FSMHelper
{
    /// <summary>
    /// Base class for a state
    /// When making states for your statemachine, you need to inherit this class.
    /// Please do not maintain unnessary references to states in your gameplay code, allow the statemachine framework to manage the states.
    /// </summary>
    public class BaseFSMState : FSMStateInterface
    {
        private FSMStateMachineLogic m_OwnerLogic = null;

        /// <summary>
        /// Default constructor for the state. 
        /// In your inherited class, you can create constructors with different parameters 
        /// to represent entry points. Calling a transition to that state with arguments will use the constructor
        /// matching those arguments
        /// </summary>
        public BaseFSMState() { }

        /// <summary>
        /// Sets up the structure of the state. Determines if it has children, and if the state is an OR vs AND state.
        /// </summary>
        /// <param name="stateType"> States of type OR means that only one of its children is active at any one time. Type AND means all its children states are active</param>
        /// <param name="children"> The list of child states for this state. If the state type is OR, the first child in this list will be the initial active state. </param>
        public virtual void SetupDefinition(ref FSMStateType stateType, ref List<System.Type> children) { }

        /// <summary>
        /// Enter() is called when the statemachine enters this state
        /// </summary>
        public virtual void Enter() { }

        /// <summary>
        /// Update() is called if this state is active when the statemachine updates
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Exit() is called when the statemachine exits this stage
        /// </summary>
        public virtual void Exit() { }

        /// <summary>
        /// ReceiveMessage will be called when a message is broadcasted to the statemachine while this state is active
        /// </summary>
        public virtual void ReceiveMessage(object[] args) { }

        /// <summary>
        /// Internal system function, do not call this from your gameplay code!
        /// </summary>
        public void _InternalSetOwnerLogic(FSMStateMachineLogic ownerLogic)
        {
            m_OwnerLogic = ownerLogic;
        }

        /// <summary>
        /// You can call DoTransition to transition your state to another state
        /// 'nextState' should be a sibling state of the current state, ie in the statemachine definition, 
        /// the nextState and this state are children of the same parent.
        /// </summary>
        /// <param name="nextState"> The state you need to transition to. This should a sibling of the current state, 
        /// ie in the statemachine definition, the current state nextState are children of the same parent.</param>
        /// <param name="args"> These arguments will be used to choose which constructor of the next state will be called.</param>
        /// <returns> Returns if the transition was successful or not.</returns>
        public bool DoTransition(System.Type nextState, object[] args = null)
        {
            Debug.Assert(m_OwnerLogic != null, "Cannot do transition before state has been entered.");
            return m_OwnerLogic.DoTransition(nextState, args);
        }

        /// <summary>
        /// This function can be used to broadcast a message to all active states in the statemachine.
        /// ReceiveMessage(..) will be called on all active states with the specified arguments.
        /// </summary>
        /// <param name="args"> The arguments to send in the message. </param>
        protected void BroadcastMessage(object[] args)
        {
            Debug.Assert(m_OwnerLogic != null, "Cannot broadcast transition before state has been entered");
            m_OwnerLogic.BroadcastMessage(args);
        }

        /// <summary>
        /// Gets the parent state that this state is a child of.
        /// </summary>
        /// <returns> Returns the parent state. This will be null at the root of the statemachine. </returns>
        public BaseFSMState GetParentState()
        {
            return m_OwnerLogic.GetParentState();
        }

        /// <summary>
        /// Gets the statemachine that this state belongs to.
        /// </summary>
        /// <returns> Returns the statemachine. </returns>
        public FSMStateMachine GetStateMachine()
        {
            return m_OwnerLogic.GetStateMachine();
        }
    }
}