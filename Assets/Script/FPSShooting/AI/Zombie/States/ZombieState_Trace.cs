using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMHelper;

public class ZombieState_Trace : BaseFSMState
{
    private ZombieStateMachine _zombieSM;
    private Transform _target;

    public override void Enter()
    {
        if (_zombieSM == null)
        {
            _zombieSM = (ZombieStateMachine)GetStateMachine();
        }
        Debug.Log("========= Enter state Trace");
    }
    public override void Update()
    {
        _zombieSM.ZombieAI.Agent.SetDestination(Player.Instance.PlayerFoot.transform.position);

        if (Vector3.Distance(_zombieSM.ZombieAI.transform.position, _zombieSM.ZombieAI.SpawnPos.position) > 30f)
        {
            DoTransition(typeof(ZombieState_ComeBack));
        }
        else if (Vector3.Distance(_zombieSM.ZombieAI.transform.position, Player.Instance.PlayerFoot.transform.position) <= 2f)
        {
            DoTransition(typeof(ZombieState_Attack));
        }
    }
    public override void Exit()
    {
    }
    public override void ReceiveMessage(object[] args)
    {
        if (args.Length == 1 && (string)args[0] == "Attack")
        {
            DoTransition(typeof(ZombieState_Attack));
        }
        else if (args.Length == 1 && (string)args[0] == "ComeBack")
        {
            DoTransition(typeof(ZombieState_ComeBack));
        }
    }
}
