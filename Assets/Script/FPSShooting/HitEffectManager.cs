using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectManager : MonoBehaviour
{
    public HitEffectMapper[] effectMap;
}

[System.Serializable]
public class HitEffectMapper
{
    public HitSurfaceType surface;
    public GameObject effectPrefab;
}

public enum HitSurfaceType
{
    Dirt = 0,
    Blood = 1
}
