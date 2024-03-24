using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMHelper;
using UnityEngine.AI;

public class ZombieState_Idle : BaseFSMState
{
    private ZombieStateMachine _zombieSM;

    private Transform _patrolCenter;
    public float patrolRadius = 10f;
    public float minDistanceToTarget = 2f;
    public float stoppingDistance = 1f;
    public float speed = 3f;

    private NavMeshAgent _agent;

    public override void Enter()
    {
        //Debug.Log("========= Enter state Idle");

        if (_zombieSM == null)
        {
            _zombieSM = (ZombieStateMachine)GetStateMachine();
        }

        _patrolCenter = _zombieSM.ZombieAI.SpawnPos;
        _agent = _zombieSM.ZombieAI.Agent;
        _agent.speed = speed;
        _agent.stoppingDistance = stoppingDistance;

        SetNewDestination();

        _zombieSM.ZombieAI.Animator.SetBool("IsWalking", true);
    }
    public override void Update()
    {
        if (!_zombieSM.ZombieAI.Agent.pathPending && _zombieSM.ZombieAI.Agent.remainingDistance <= _zombieSM.ZombieAI.Agent.stoppingDistance)
        {
            SetNewDestination();
        }
    }
    public override void Exit()
    {
    }

    void SetNewDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        Vector3 newDestination = _patrolCenter.position + randomDirection;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(newDestination, out hit, patrolRadius, NavMesh.AllAreas))
        {
            _zombieSM.ZombieAI.Agent.SetDestination(hit.position);
        }
    }

    public override void ReceiveMessage(object[] args)
    {
       // Debug.Log("============ State Idle receved message : " + args.ToString());
        if (args.Length == 1 && (string)args[0] == "Trace")
        {
            DoTransition(typeof(ZombieState_Trace));
        }
    }
}
