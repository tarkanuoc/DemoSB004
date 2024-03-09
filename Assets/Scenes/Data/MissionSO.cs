using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Create Mission")]
public class MissionSO : ScriptableObject
{
    public List<MissionInfo> listMission = new List<MissionInfo>();
}

[System.Serializable]
public class MissionInfo
{
    public int NumKill;
}
