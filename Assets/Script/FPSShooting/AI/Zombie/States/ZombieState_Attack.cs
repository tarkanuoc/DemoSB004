using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMHelper;

public class ZombieState_Attack : BaseFSMState
{
    private ZombieStateMachine _zombieSM;

    public override void Enter()
    {
        Debug.Log("============ Zombie Attaack");
        if (_zombieSM == null)
        {
            _zombieSM = (ZombieStateMachine)GetStateMachine();
        }
        _zombieSM.ZombieAI.ZombieAttack.StartAttack();
    }
    public override void Update()
    {
        _zombieSM.ZombieAI.Agent.SetDestination(Player.Instance.PlayerFoot.transform.position);

        if (Vector3.Distance(_zombieSM.ZombieAI.transform.position, _zombieSM.ZombieAI.SpawnPos.position) > 30f)
        {
            DoTransition(typeof(ZombieState_ComeBack));
        }
    }
    public override void Exit()
    {
        _zombieSM.ZombieAI.ZombieAttack.StopAttack();
    }
    public override void ReceiveMessage(object[] args)
    {
        if (args.Length == 1 && (string)args[0] == "ComeBack")
        {
            DoTransition(typeof(ZombieState_ComeBack));
        }
    }
}
