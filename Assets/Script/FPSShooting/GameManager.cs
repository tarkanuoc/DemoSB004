using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject PanelGameOver;
    [SerializeField] private GameObject PanelGameWin;
    [SerializeField] private CinemachineVirtualCameraBase vcam;
    public int CurrentLevel;
    private bool _isZoomMode;
    public bool IsZoomMode
    {
        get => _isZoomMode;
        set => _isZoomMode = value;
    }


    public CinemachineVirtualCameraBase CamZoom => vcam;

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
