using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private AutoFade leftScratch;
    [SerializeField] private AutoFade rightScratch;
    private static PlayerUI _instance;
    public static PlayerUI Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
            Instance = _instance;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void ShowLeftScratch()
    {
        leftScratch.Show();
    }

    public void ShowRightScratch()
    {
        rightScratch.Show();
    }

}
