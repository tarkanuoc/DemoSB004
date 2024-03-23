using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FSMHelper
{
    /// <summary>
    /// Determines the type of state. An 'OR' state means only one of its children can be active at any time.
    /// 'AND' state means all of his children will be active at any time.
    /// </summary>
    public enum FSMStateType
    {
        Type_OR,
        Type_AND
    }

    /// <summary>
    /// This is a wrapper class to contain internal data for a state like its children, parent, etc
    /// It hides the internals from the gameplay code. The user should not have to interact with this class directly.
    /// </summary>
    public class FSMStateMachineLogic
    {
        private BaseFSMState m_State = null;
        private FSMStateMachine m_OwnerSM = null;
        private FSMStateMachineLogic m_Parent = null;
        private List<FSMStateMachineLogic> m_ChildSMs = new List<FSMStateMachineLogic>();

        private System.Type m_StateClass = null;
        private FSMStateType m_StateType = FSMStateType.Type_OR;
        private List<System.Type> m_ChildrenTypes = null;

        public FSMStateMachineLogic(FSMStateType stateType, List<System.Type> childrenTypes, FSMStateMachine ownerSM, FSMStateMachineLogic parent)
        {
            m_StateClass = null;
            m_StateType = stateType;
            m_ChildrenTypes = childrenTypes;
            m_Parent = parent;
            m_OwnerSM = ownerSM;
        }

        public FSMStateMachineLogic(System.Type stateClass, FSMStateMachine ownerSM, FSMStateMachineLogic parent)
        {
            m_ChildrenTypes = new List<System.Type>();
            m_StateClass = stateClass;
            m_OwnerSM = ownerSM;
            m_Parent = parent;
        }

        /// <summary>
        /// Recursive function to get the hierarchy of current active states
        /// </summary>
        /// <returns> Returns the text string containing the hierarchy of active states</returns>
        public string GetActiveStateTreeText(int level)
        {
            string result = "";

            if (m_State != null)
            {
                for (int i = 0; i < level * 4; i++)
                {
                    result += " ";
                }
                result += m_State.ToString();
                result += "\n";
            }

            for (int i = 0; i < m_ChildSMs.Count; i++)
            {
                result += m_ChildSMs[i].GetActiveStateTreeText(level + 1);
            }

            return result;
        }

        /// <summary>
        /// Accessor to get the parent state. 
        /// </summary>
        /// <returns> Returns the parent state. This can be null if it is in the root of the statemachine. </returns>
        public BaseFSMState GetParentState()
        {
            if (m_Parent == null)
                return null;

            return m_Parent.m_State;
        }

        /// <summary>
        /// Accessor to get the state machine object 
        /// </summary>
        /// <returns> Returns the state machine. </returns>
        public FSMStateMachine GetStateMachine()
        {
            return m_OwnerSM;
        }

        /// <summary>
        /// Enters the specified state. It will also enter all necessary children state.
        /// </summary>
        /// <param name="args"> The arguments passed in the transition. The state's constructor will be chosen to match the arguments specified.
        /// If args is null, the default constructor will be used.</param>
        public void Enter(object[] args)
        {
            // create an instance of the actual state
            // call enter on it

            if (m_StateClass != null)
            {
                m_State = (BaseFSMState)System.Activator.CreateInstance(m_StateClass, args);
                m_State._InternalSetOwnerLogic(this);
                m_State.SetupDefinition(ref m_StateType, ref m_ChildrenTypes);
                m_State.Enter();
            }

            // create an instance of the necessary child state machines
            // call enter on them


            for (int i = 0; i < m_ChildrenTypes.Count; i++)
            {
                FSMStateMachineLogic childSM = new FSMStateMachineLogic(m_ChildrenTypes[i], m_OwnerSM, this);
                m_ChildSMs.Add(childSM);
                childSM.Enter(null);
                if (m_StateType == FSMStateType.Type_OR)
                {
                    // just add the first child and exit
                    break;
                }
                // else add all the children
            }
        }

        /// <summary>
        /// Exits the specified state. All children states will be exited before calling exit on m_State
        /// </summary>
        public void Exit()
        {
            for (int i = 0; i < m_ChildSMs.Count; i++)
            {
                m_ChildSMs[i].Exit();
            }

            if (m_State != null)
            {
                m_State.Exit();
            }

            // reset all the data in case user is holding on to the object
            m_OwnerSM = null;
            m_Parent = null;
            m_State = null;
            m_ChildSMs.Clear();
        }

        /// <summary>
        /// Update logic for the state.
        /// Note that child state updates will be called before the m_State's update.
        /// </summary>
        public void Update()
        {
            for (int i = 0; i < m_ChildSMs.Count; i++)
            {
                m_ChildSMs[i].Update();
            }

            if (m_State != null)
            {
                m_State.Update();
            }
        }

        /// <summary>
        /// Try to make one of my children transition to the specified state
        /// </summary>
        /// <param name="child"> The state that will be transitioned </param>
        /// <param name="nextState"> The state you need to transition to. This should a sibling of child.</param>
        /// <param name="args"> The arguments passed in the transition. </param>
        public bool RequestChildTransition(FSMStateMachineLogic child, System.Type nextState, object[] args)
        {
            if (m_StateType == FSMStateType.Type_AND)
            {
                return false;
            }

            for (int i = 0; i < m_ChildSMs.Count; i++)
            {
                if (m_ChildSMs[i] == child)
                {
                    // found the child, now find the definition of nextState

                    for (int j = 0; j < m_ChildrenTypes.Count; j++)
                    {
                        if (m_ChildrenTypes[j] == nextState)
                        {
                            // found the next state's definition
                            m_ChildSMs[i].Exit();
                            m_ChildSMs[i] = new FSMStateMachineLogic(nextState, m_OwnerSM, this);
                            m_ChildSMs[i].Enter(args);
                            return true;
                        }
                    }

                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Intermediary function to request the parent state to transition myself to nextState
        /// </summary>
        /// <param name="nextState"> The class type of the next state to transition to. </param>
        /// <param name="args"> The arguments of the transition. </param>
        public bool DoTransition(System.Type nextState, object[] args)
        {
            // This state wants to transition to nextState
            // Request the parent to do it

            if (m_Parent == null)
                return false;

            return m_Parent.RequestChildTransition(this, nextState, args);
        }

        /// <summary>
        /// Intermediary function to notify the state machine to broadcast the message to all states recursively
        /// </summary>
        /// <param name="args"> The arguments of the message </param>
        public void BroadcastMessage(object[] args)
        {
            m_OwnerSM.BroadcastMessage(args);
        }

        /// <summary>
        /// Intermediary function to recursively pass the message to all children
        /// </summary>
        /// <param name="args"> The arguments of the message </param>
        public void ReceiveMessage(object[] args)
        {
            // notify all the children first
            for (int i = 0; i < m_ChildSMs.Count; i++)
            {
                m_ChildSMs[i].ReceiveMessage(args);
            }

            if (m_State != null)
            {
                m_State.ReceiveMessage(args);
            }
        }

        /// <summary>
        /// Helper function to know if a state is currently active in the statemachine.
        /// </summary>
        /// <param name="stateMachineDefinition"> The class type of the state to check </param>
        /// <returns> Returns true if the state is active. </returns>
        public bool IsInState(System.Type state)
        {
            if (m_StateClass == state)
                return true;

            for (int i = 0; i < m_ChildSMs.Count; i++)
            {
                if (m_ChildSMs[i].IsInState(state))
                    return true;
            }

            return false;
        }
    }
}