using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] guns;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)
                || Input.GetKeyDown(KeyCode.Keypad1 + i))
            {
                SetActiveGun(i);
            }
        }    
    }

    private void SetActiveGun(int gunIndex)
    {
        for (int i = 0; i < guns.Length; i++)
        {
            bool isActive = (i == gunIndex);
            guns[i].SetActive(isActive);

            if (isActive)
            {
                guns[i].SendMessage("OnGunSelected");
            }
        }
    }
}
