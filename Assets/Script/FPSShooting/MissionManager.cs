using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionManager : Singleton<MissionManager>
{
    [SerializeField] private MissionSO missionSO;
    [SerializeField] private TextMeshProUGUI textMission;
    [SerializeField] private Gate exitDoor;

    private int requiredKill;
    private int currentKill;
    private bool isPlayerExit;

    private void Start()
    {
        InitMisson();
        StartCoroutine(VerifyMissions());
    }

    IEnumerator VerifyMissions()
    {
        yield return VerifyZombieKill();
        yield return VerifyPlayerExit();
       // yield return new WaitForSeconds(3f);
        GameManager.Instance.OnMissionCompleted();
    }

    private IEnumerator VerifyZombieKill()
    {
        currentKill = 0;
        textMission.text = $"Kill {requiredKill} zombie" + $" - Current Kill : {currentKill}";
        yield return new WaitUntil(() => IsCompletedMission());
    }

    private IEnumerator VerifyPlayerExit()
    {
        textMission.text = $"Find Exit Door";
        exitDoor.onPlayerEnter.AddListener(OnPlayerExit);
        yield return new WaitUntil(() => isPlayerExit);
        exitDoor.onPlayerEnter.RemoveListener(OnPlayerExit);
    }

    public void OnZombieKilled()
    {
        currentKill++;
        textMission.text = $"Kill {requiredKill} zombie" + $" - Current Kill : {currentKill}";
        Debug.Log("======= OnZombieKilled");
    }

    private void InitMisson()
    {
        var index = GameManager.Instance.CurrentLevel - 1;
        var numKillMission = missionSO.listMission[index].NumKill;
        requiredKill = numKillMission;
    }

    bool IsCompletedMission()
    {
        return currentKill >= requiredKill;
    }

    //bool IsPlayerExit()
    //{
    //    float distance = Vector3.Distance(Player.Instance.PlayerFoot.position, exitDoor.position);
    //    return distance < 1f;
    //}

    private void OnPlayerExit()
    {
        isPlayerExit = true;
    }
}
