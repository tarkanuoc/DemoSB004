using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using FSMHelper;

public class PlayerBehavior : MonoBehaviour
{
    // keep an instance of our state machine
    private PlayerBehaviorStateMachine m_PlayerSM = null;

    void Start ()
    {
        // create the state machine and start it
        m_PlayerSM = new PlayerBehaviorStateMachine(this.gameObject);
        m_PlayerSM.StartSM();
    }
	
	void Update ()
    {
        // update the state machine very frame
        m_PlayerSM.UpdateSM();

        // this is how you can print the current active state tree to the log for debugging
        if (Input.GetButtonDown("Fire2"))
        {
            m_PlayerSM.PrintActiveStateTree();
        }
    }

    void OnDestroy()
    {
        // stop the state machine to ensure all the Exit() gets called
        if (m_PlayerSM != null)
        {
            m_PlayerSM.StopSM();
            m_PlayerSM = null;
        }
    }
}
