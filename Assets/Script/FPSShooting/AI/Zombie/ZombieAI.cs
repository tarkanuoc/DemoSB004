using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FSMHelper;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private ZombieAttack zombieAttack;


    public Animator Animator => animator;
    public NavMeshAgent Agent => agent;
    public ZombieAttack ZombieAttack => zombieAttack;
    public Transform SpawnPos;

    private ZombieStateMachine m_ZombieSM = null;

    void Start()
    {
        m_ZombieSM = new ZombieStateMachine(this);
        m_ZombieSM.StartSM();
    }

    void Update()
    {
        m_ZombieSM.UpdateSM();
    }

    void OnDestroy()
    {
        if (m_ZombieSM != null)
        {
            m_ZombieSM.StopSM();
            m_ZombieSM = null;
        }
    }

    public void TracePlayer()
    {
        object[] args = new object[1];
        args[0] = "Trace";
        m_ZombieSM.BroadcastMessage(args);
    }

    public void ComeBack()
    {
        object[] args = new object[1];
        args[0] = "ComeBack";
        m_ZombieSM.BroadcastMessage(args);
    }

    public void Attack()
    {
        object[] args = new object[1];
        args[0] = "Attack";
        m_ZombieSM.BroadcastMessage(args);
    }

    public void Patrol()
    {
        object[] args = new object[1];
        args[0] = "Patrol";
        m_ZombieSM.BroadcastMessage(args);
    }
}
