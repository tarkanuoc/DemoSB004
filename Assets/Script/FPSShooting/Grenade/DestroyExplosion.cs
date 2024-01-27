using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    public float delayTime = 5f;
    void Start()
    {
        Destroy(gameObject, delayTime);
    }
}
