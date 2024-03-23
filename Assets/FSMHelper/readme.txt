Finite State Machine Helper
~~~~~~~~~~~~~~~~~~~~~~~~~~~
Fairuz Lokman
fairooze@gmail.com

Online Documentation:
- http://www.respawnpoint.net/fsmhelper/

-------------------------------------------

Finite State Machine Helper is a highly robust yet lightweight C# framework to implement state machines in your project. It supports both simple state machines as well as very complex multi-level nested states.

Basic features
~~~~~~~~~~~~~

- Use your own classes with Enter(), Exit() and Update() functions for states. Develop state machines like a professional, no more silly enums and switch cases!

- Just call a single line of code to transition to another state, the framework will automatically Exit() the current state and Enter() the next state.

Advanced features
~~~~~~~~~~~~~~~~~

- Nested states within states! Rather than just a single layer of states, your states could have states within them as well, with unlimited depth. For eg, your character has an Alive and Dead state, and the Alive State is broken down further into Walking and Swimming states. 

- AND vs OR states. If a state has children, specifying it as an OR state means that only one child state is active at any time. Specifying it as an AND state means all children states are active. Very useful for running monitors/managers in parallel!

- Passing parameters during transitions. When your character transitions from Idle to Combat state, you can send the enemy character's GameObject (or any parameters) inside the transition, and this will automatically call the Combat state's constructor that matches those parameters.

- Broadcast messages to all active states in the state machine. This is useful if you have a complex multi-level state tree and need to transition a state from within a different state, or you want multiple states to transition with one line of code.

- Override the state machine class with your own class! This way you can have your own member variables accessible to any active state in the state machine, regardless of its depth.

- Easy debugging! Watching the state machine object in the debugger will allow you to expand the entire tree of currently active states. You can also print the current tree to the log anytime by iterating through the tree.

- Define your statemachine structure with simple, easy-to-read syntax. No need to struggle with GUI tools.

Demo scene
~~~~~~~~~~

The demo scene is an example of a multi-level state machine, with both AND and OR states within it.
It has examples of transitions, as well as broadcasted messages.

Open FSMHelperScene and play it.

Controls:
- Vertical axis: Go to walk state
- Jump: Go to jump state
- Fire1: Go to Under attack state (which runs in parallel to walk/jump)
- Fire2: Print statemachine debug to log
- Fire3: Go to death state (irreversible)

Quickstart guide
~~~~~~~~~~~~~~~~

All you need is in the FSMHelper/FSMHelper_Library folder. The other folder is purely for demonstration purposes.

1) Create you own state class(es), inherit from BaseFSMState
    - Override Enter(), Exit(), Update() functions
    
    eg:
    public class AliveState : BaseFSMState
    {
        public override void Enter() { }
        public override void Update() { }
        public override void Exit() { }
    }
    
2) Create your own FSM class, inherit from FSMStateMachine
    - Override SetupDefinition() to specify the state classes you created
    
    eg:
    public class BehaviorStateMachine : FSMStateMachine
    {
        public override void SetupDefinition(ref FSMStateType stateType, ref List<System.Type> children)
        {
            children.Add(typeof(AliveState));
            children.Add(typeof(DeadState));
        }
    }
    
3) Instantiate the FSM in your game monobehavior, start the FSM, and update it every frame

    eg:
    public class PlayerBehavior : MonoBehaviour
    {
        private BehaviorStateMachine m_PlayerSM = null;

        void Start ()
        {
            m_PlayerSM = new BehaviorStateMachine();
            m_PlayerSM.StartSM();
        }
        
        void Update ()
        {
            m_PlayerSM.UpdateSM();
        }

        void OnDestroy()
        {
            if (m_PlayerSM != null)
            {
                m_PlayerSM.StopSM();
                m_PlayerSM = null;
            }
        }
    }

Release notes
~~~~~~~~~~~~~

v1.0:
- Initial release


Copyright
~~~~~~~~~
Copyright 2015 by Fairuz Lokman
All Rights Reserved.