using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunAmmo : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public int magSize;
    public GrenadeLauncher gun;

    [SerializeField] private AudioSource[] reloadsounds;

    private int _loadedAmmo;

    public UnityEvent loadedAmmoChanged;


    private void Start()
    {
        RefillAmmo();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    public int LoadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            _loadedAmmo = value;
            loadedAmmoChanged.Invoke();
            if (_loadedAmmo <= 0)
            {
                Reload();
            }
            else
            {
                UnlockShooting();
            }
        }
    }

    private void Reload()
    {
        animator.SetTrigger("Reload");
        LockShooting();
    }

    private void LockShooting()
    {
        gun.enabled = false;
    }

    private void UnlockShooting()
    {
        gun.enabled = true;
    }

    private void RefillAmmo()
    {
        LoadedAmmo = magSize;
    }

    public void AddAmmo()
    {
        RefillAmmo();
    }

    public void PlayReloadPart1Sound()
    {
        reloadsounds[0].Play();
    }

    public void PlayReloadPart2Sound()
    {
        reloadsounds[1].Play();
    }

    public void PlayReloadPart3Sound()
    {
        reloadsounds[2].Play();
    }

    public void PlayReloadPart4Sound()
    {
        reloadsounds[3].Play();
    }

    public void PlayReloadPart5Sound()
    {
        reloadsounds[4].Play();
    }
}
