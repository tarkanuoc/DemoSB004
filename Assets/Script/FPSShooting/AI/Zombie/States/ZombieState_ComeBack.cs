using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMHelper;

public class ZombieState_ComeBack : BaseFSMState
{
    private ZombieStateMachine _zombieSM;

    public override void Enter()
    {
        if (_zombieSM == null)
        {
            _zombieSM = (ZombieStateMachine)GetStateMachine();
        }
       
    }
    public override void Update()
    {
        _zombieSM.ZombieAI.Agent.SetDestination(_zombieSM.ZombieAI.SpawnPos.position);
       
        if (Vector3.Distance(_zombieSM.ZombieAI.transform.position, _zombieSM.ZombieAI.SpawnPos.position) <= 1f)
        {
            DoTransition(typeof(ZombieState_Idle));
        }
    }
    public override void Exit()
    {
    }
    public override void ReceiveMessage(object[] args)
    {
        if (args.Length == 1 && (string)args[0] == "Patrol")
        {
            DoTransition(typeof(ZombieState_Idle));
        }
    }
}
