using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject PanelGameOver;
    [SerializeField] private GameObject PanelGameWin;

    public int CurrentLevel;

    private void Start()
    {
        CurrentLevel = 1;
    }

    private void StopGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void OnGameover()
    {
        StopGame();
        PanelGameOver.SetActive(true);
    }

    public void OnMissionCompleted()
    {
        StopGame();
        PanelGameWin.SetActive(true);
    }
}
