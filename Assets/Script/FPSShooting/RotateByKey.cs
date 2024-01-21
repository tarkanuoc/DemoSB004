using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByKey : MonoBehaviour
{
    public float anglePerSecond;
    private float x;
    private bool IsStopRotate;
    void Update()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            IsStopRotate = false;
            x -= 0.05f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            IsStopRotate = false;
            x += 0.05f;
        }

        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
        {
            IsStopRotate = true;
            x = 0;
        }

        if (!IsStopRotate)
        {
            float yaw = x * anglePerSecond * Time.deltaTime;
            transform.Rotate(0, yaw, 0);
        }
    }
}
